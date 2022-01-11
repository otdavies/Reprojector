using System;
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
    private Vector3[] _origin_vertices = { new Vector3(1, 1, 0), new Vector3(0, 1, 0), new Vector3(1, 0, 0), new Vector3(0, 0, 0) };
    private MonoBehaviour _mono;
    private Quad _deformQuad;

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
        _deformQuad = new Quad(_mesh_filter, 32, 18);
        FitQuadToScreen();
    }

    public void SetupNDI(NdiResources _resources)
    {
        // Setup NDI
        _ndi = _quad.AddComponent<NdiReceiver>();
        _ndi.SetResources(_resources);
        _ndi.targetRenderer = _quad.GetComponent<MeshRenderer>();
        _ndi.targetTexture = new RenderTexture(1920, 1080, 24, RenderTextureFormat.ARGB32);
        _ndi.targetMaterialProperty = "_MainTex";
        _mono.StartCoroutine(WaitForNetworkScan(2.0f));
    }

    private IEnumerator WaitForNetworkScan(float scan_wait)
    {
        yield return new WaitForSeconds(scan_wait);
        _ndi.ndiName = NdiFinder.sourceNames.Where(x => x.Contains("Arena")).FirstOrDefault();
        Debug.LogError(_ndi.ndiName);
    }

    public void PanTiltZoom(float pan, float tilt, float zoom)
    {
        _zoom = Mathf.Clamp(zoom, 0, _max_zoom * 2);

        tilt *= 0.5f * 0.5625f;
        pan *= 0.5f;
        float top_tilt = Mathf.Max(tilt, 0);
        float bot_tilt = -Mathf.Min(tilt, 0);
        float lft_pan = Mathf.Max(pan, 0);
        float rgt_pan = -Mathf.Min(pan, 0);

        Vector3 c0_tilt = Vector3.Lerp(_origin_vertices[0], _origin_vertices[1], top_tilt);
        Vector3 c1_tilt = Vector3.Lerp(_origin_vertices[1], _origin_vertices[0], top_tilt);
        Vector3 c2_tilt = Vector3.Lerp(_origin_vertices[2], _origin_vertices[3], bot_tilt);
        Vector3 c3_tilt = Vector3.Lerp(_origin_vertices[3], _origin_vertices[2], bot_tilt);

        Vector3 c0_pan = Vector3.Lerp(_origin_vertices[0], _origin_vertices[2], lft_pan);
        Vector3 c1_pan = Vector3.Lerp(_origin_vertices[1], _origin_vertices[3], rgt_pan);
        Vector3 c2_pan = Vector3.Lerp(_origin_vertices[2], _origin_vertices[0], lft_pan);
        Vector3 c3_pan = Vector3.Lerp(_origin_vertices[3], _origin_vertices[1], rgt_pan);

        _vertices[0] = Vector3.Lerp(c0_tilt, c0_pan, 0.5f);
        _vertices[1] = Vector3.Lerp(c1_tilt, c1_pan, 0.5f);
        _vertices[2] = Vector3.Lerp(c2_tilt, c2_pan, 0.5f);
        _vertices[3] = Vector3.Lerp(c3_tilt, c3_pan, 0.5f);

        _deformQuad.UpdateQuad(_vertices[0], _vertices[1], _vertices[2], _vertices[3]);
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
        Array.Copy(_vertices, _origin_vertices, 4);
    }
}