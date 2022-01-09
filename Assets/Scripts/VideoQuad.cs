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
    private float _max_zoom = 0;
    private float _tilt = 0;
    private float _pan = 0;
    private float _zoom = 0;
    private float _plane_origin;
    public VideoQuad(MonoBehaviour mono, Camera camera, float max_tilt, float max_pan, float max_zoom)
    {
        _mono = mono;
        _camera = camera;
        _max_tilt = max_tilt;
        _max_pan = max_pan;
        _max_zoom = max_zoom;
        _plane_origin = _camera.farClipPlane * 0.25f;
        CreateQuad();
    }

    public void CreateQuad()
    {
        // Setup Quad
        _quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _quad_material = new Material(Shader.Find("Unlit/Video"))
        {
            mainTexture = Resources.Load<Texture2D>("Default")
        };
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
        _ndi.ndiName = NdiFinder.sourceNames.Where(x => x.Contains("Arena")).FirstOrDefault();
        Debug.Log(_ndi.ndiName);
    }

    public void PanTiltZoom(float pan, float tilt, float zoom)
    {
        _pan = Mathf.Clamp(pan, -_max_pan, _max_pan);
        _tilt = Mathf.Clamp(tilt, -_max_tilt, _max_tilt);
        _zoom = Mathf.Clamp(zoom, -_max_zoom * 0.5f, _max_zoom * 2);
        Vector3 anchor = _camera.transform.forward * _plane_origin;
        float height = _quad_height * 0.5f;
        float width = _quad_width * 0.5f;

        // Determine forward offset
        float tilt_indent = Mathf.Sin(Mathf.Abs(_tilt) * Mathf.Deg2Rad) * height;
        float pan_indent = Mathf.Sin(Mathf.Abs(_pan) * Mathf.Deg2Rad) * width;

        float adjacent_tilt = Mathf.Cos(Mathf.Abs(_tilt) * Mathf.Deg2Rad);
        float adjacent_pan = Mathf.Cos(Mathf.Abs(_pan) * Mathf.Deg2Rad);

        float tilt_offset = Mathf.Sign(_tilt) > 0 ? (height * adjacent_tilt - height) : (height - height * adjacent_tilt);
        float pan_offset = Mathf.Sign(_pan) > 0 ? (width - width * adjacent_pan) : (width * adjacent_pan - width);

        Vector3 offset = ((Mathf.Max(tilt_indent, pan_indent) + _zoom) * _camera.transform.forward) + (tilt_offset * _camera.transform.up) + (pan_offset * _camera.transform.right);
        _quad.transform.SetPositionAndRotation(anchor + offset, Quaternion.AngleAxis(_tilt, Vector3.right) * Quaternion.AngleAxis(_pan, Vector3.up));
    }

    private void FitQuadToScreen()
    {
        _quad.transform.position = _camera.transform.position + _camera.transform.forward * _plane_origin;
        _quad.transform.forward = -_camera.transform.forward;
        _quad.transform.up = Vector3.up;

        float plane_dist = _plane_origin;
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