using System.Collections;
using System.Linq;
using Klak.Ndi;
using UnityEngine;
internal class VideoQuad
{
    private Camera _camera;
    private GameObject _quad;
    private MeshFilter _mesh_filter;
    private NdiReceiver _ndi;
    private RenderTexture _render_texture;
    private Material _quad_material;
    private Vector3[] _vertices = { new Vector3(1, 1, 0), new Vector3(0, 1, 0), new Vector3(1, 0, 0), new Vector3(0, 0, 0) };
    private MonoBehaviour _mono;

    private float _quad_height = 0;
    private float _quad_width = 0;
    private float _max_tilt = 0;
    private float _max_pan = 0;
    private float _tilt = 0;
    private float _pan = 0;
    public VideoQuad(MonoBehaviour mono, Camera camera, float max_tilt, float max_pan)
    {
        _max_tilt = max_tilt;
        _max_pan = max_pan;
        _mono = mono;
        _camera = camera;
        CreateQuad();
    }

    public void CreateQuad()
    {
        _quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _quad.transform.position = _camera.transform.position + _camera.transform.forward * _camera.farClipPlane * 0.5f;
        _quad.transform.forward = -_camera.transform.forward;
        _quad.transform.up = Vector3.up;
        _quad_material = new Material(Shader.Find("Unlit/Video"));
        _quad_material.mainTexture = Resources.Load<Texture2D>("Default");
        _quad.GetComponent<MeshRenderer>().material = _quad_material;
        GameObject.Destroy(_quad.GetComponent<Collider>());

        // Mesh setup
        _mesh_filter = _quad.GetComponent<MeshFilter>();
        _mesh_filter.mesh.MarkDynamic();
        FitQuadToScreen();

        // Setup NDI
        _ndi = _quad.AddComponent<NdiReceiver>();
        _ndi.targetRenderer = _quad.GetComponent<MeshRenderer>();
        _ndi.targetMaterialProperty = "_MainTex";
        _mono.StartCoroutine(WaitForNetworkScan(0.5f));
    }

    private IEnumerator WaitForNetworkScan(float scan_wait)
    {
        yield return new WaitForSeconds(scan_wait);
        _ndi.ndiName = NdiFinder.sourceNames.Where(x => x.Contains("Reprojector")).FirstOrDefault();
        Debug.Log(_ndi.ndiName);
    }

    public void PanTilt(float pan, float tilt)
    {
        _pan = Mathf.Clamp(_pan + pan, -_max_pan, _max_pan);
        _tilt = Mathf.Clamp(_tilt + tilt, -_max_tilt, _max_tilt);
        Vector3 anchor = _camera.transform.forward * _camera.farClipPlane * 0.5f;

        float max_offset = Mathf.Max(Mathf.Abs(_tilt), Mathf.Abs(_pan));
        float opposite = Mathf.Sin(max_offset * Mathf.Deg2Rad);
        float adjacent = Mathf.Cos(max_offset * Mathf.Deg2Rad);
        float height = _quad_height * 0.5f;
        float width = _quad_width * 0.5f;

        float vertical_offset = Mathf.Sign(_tilt) > 0 ? (height * adjacent - height) : (height - height * adjacent);
        float horizontal_offset = Mathf.Sign(_pan) < 0 ? (width * adjacent - width) : (width - width * adjacent);

        Vector3 offset = (height * opposite * _camera.transform.forward) + (vertical_offset * _camera.transform.up) + (horizontal_offset * _camera.transform.right);
        _quad.transform.SetPositionAndRotation(anchor + offset, Quaternion.AngleAxis(_tilt, Vector3.right) * Quaternion.AngleAxis(_pan, Vector3.up));
    }

    private void FitQuadToScreen()
    {
        float plane_dist = _camera.farClipPlane * 0.5f;
        Vector3 offset = _camera.transform.forward * plane_dist;
        _vertices[0] = _camera.ScreenToWorldPoint(new Vector3(0, 0, plane_dist)) - offset;
        _vertices[1] = _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, plane_dist)) - offset;
        _vertices[2] = _camera.ScreenToWorldPoint(new Vector3(0, Screen.height, plane_dist)) - offset;
        _vertices[3] = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, plane_dist)) - offset;
        _quad_height = Vector3.Distance(_vertices[0], _vertices[2]);
        _quad_width = Vector3.Distance(_vertices[0], _vertices[1]);
        _mesh_filter.mesh.SetVertices(_vertices);
    }
}