using System.Collections;
using System.Linq;
using Klak.Ndi;
using UnityEngine;
internal class RenderQuad
{
    private Camera _camera;
    private GameObject _quad;
    private MeshFilter _mesh_filter;
    private NdiReceiver _ndi;
    private RenderTexture _render_texture;
    private Material _quad_material;
    private Vector3[] vertices = { new Vector3(1, 1, 0), new Vector3(0, 1, 0), new Vector3(1, 0, 0), new Vector3(0, 0, 0) };
    private MonoBehaviour _mono;

    public RenderQuad(MonoBehaviour mono, Camera camera)
    {
        _mono = mono;
        _camera = camera;
        CreateQuad(3, 1280, 720);
    }

    public void CreateQuad(float distance_from_camera, int video_width, int video_height)
    {
        _quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _quad.transform.position = _camera.transform.position + _camera.transform.forward * distance_from_camera;
        _quad.transform.forward = -_camera.transform.forward;
        _quad.transform.up = Vector3.up;
        _quad_material = new Material(Shader.Find("Unlit/Texture"));
        _quad.GetComponent<MeshRenderer>().material = _quad_material;
        GameObject.Destroy(_quad.GetComponent<Collider>());

        // Mesh setup
        _mesh_filter = _quad.GetComponent<MeshFilter>();
        _mesh_filter.mesh.MarkDynamic();
        FitQuadToScreen();

        _render_texture = new RenderTexture(video_width, video_height, 16, RenderTextureFormat.ARGB32);
        _quad_material.mainTexture = _render_texture;

        _ndi = _quad.AddComponent<NdiReceiver>();
        _ndi.targetRenderer = _quad.GetComponent<MeshRenderer>();
        _ndi.targetTexture = _render_texture;
        _ndi.targetMaterialProperty = "_MainTex";
        _mono.StartCoroutine(WaitForNetworkScan(2));
    }

    private IEnumerator WaitForNetworkScan(float scan_wait)
    {
        yield return new WaitForSeconds(scan_wait);
        _ndi.ndiName = NdiFinder.sourceNames.Where(x => x.Contains("Reprojector")).FirstOrDefault();
        Debug.Log(_ndi.ndiName);
    }

    public void UpdateQuadMesh(Vector3 ul, Vector3 ur, Vector3 lr, Vector3 ll)
    {
        vertices[0] = ul;
        vertices[1] = ur;
        vertices[2] = lr;
        vertices[3] = ll;
        _mesh_filter.mesh.SetVertices(vertices);
    }

    private void FitQuadToScreen()
    {
        vertices[0] = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        vertices[1] = _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        vertices[2] = _camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        vertices[3] = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _mesh_filter.mesh.SetVertices(vertices);
    }
}