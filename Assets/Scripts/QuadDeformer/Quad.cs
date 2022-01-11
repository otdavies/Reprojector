using UnityEngine;

public class Quad
{
    public int _xdivisions = 3;
    public int _ydivisions = 3;
    private MeshFilter _meshFilter;
    private Vector3[] _vertices;

    public Quad(MeshFilter meshFilter, int x, int y)
    {
        _xdivisions = x;
        _ydivisions = y;
        _meshFilter = meshFilter;
        _meshFilter.mesh.MarkDynamic();
        CreateQuadAndSet(Vector3.zero, Vector3.right, Vector3.up, Vector3.right + Vector3.up);
    }

    private void CreateQuadAndSet(Vector3 cp0, Vector3 cp1, Vector3 cp2, Vector3 cp3)
    {
        Mesh mesh = _meshFilter.mesh;
        mesh.Clear();
        _vertices = new Vector3[(_xdivisions + 1) * (_ydivisions + 1)];
        Vector2[] uv = new Vector2[_vertices.Length];
        Vector4[] tangents = new Vector4[_vertices.Length];
        Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
        for (int i = 0, y = 0; y <= _ydivisions; y++)
        {
            for (int x = 0; x <= _xdivisions; x++, i++)
            {
                float xPercent = (float)x / _xdivisions;
                float yPercent = (float)y / _ydivisions;
                Vector3 cp0_cp1 = Vector3.Lerp(cp0, cp1, xPercent);
                Vector3 cp2_cp3 = Vector3.Lerp(cp2, cp3, xPercent);
                Vector3 cp0_cp2 = Vector3.Lerp(cp0, cp2, yPercent);
                Vector3 cp1_cp3 = Vector3.Lerp(cp1, cp3, yPercent);
                Vector3 xx = Vector3.Lerp(cp0_cp1, cp2_cp3, yPercent);
                Vector3 yy = Vector3.Lerp(cp0_cp2, cp1_cp3, xPercent);

                _vertices[i] = (xx + yy) * 0.5f;
                uv[i] = new Vector2(xPercent, yPercent);
                tangents[i] = tangent;
            }
        }
        mesh.vertices = _vertices;
        mesh.uv = uv;
        mesh.tangents = tangents;

        int[] triangles = new int[_xdivisions * _ydivisions * 6];
        for (int ti = 0, vi = 0, y = 0; y < _ydivisions; y++, vi++)
        {
            for (int x = 0; x < _xdivisions; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + _xdivisions + 1;
                triangles[ti + 5] = vi + _xdivisions + 2;
            }
        }
        mesh.triangles = triangles;
    }

    public void UpdateQuad(Vector3 cp0, Vector3 cp1, Vector3 cp2, Vector3 cp3)
    {
        for (int i = 0, y = 0; y <= _ydivisions; y++)
        {
            for (int x = 0; x <= _xdivisions; x++, i++)
            {
                float xPercent = (float)x / _xdivisions;
                float yPercent = (float)y / _ydivisions;
                Vector3 cp0_cp1 = Vector3.Lerp(cp0, cp1, xPercent);
                Vector3 cp2_cp3 = Vector3.Lerp(cp2, cp3, xPercent);
                Vector3 cp0_cp2 = Vector3.Lerp(cp0, cp2, yPercent);
                Vector3 cp1_cp3 = Vector3.Lerp(cp1, cp3, yPercent);
                Vector3 xx = Vector3.Lerp(cp0_cp1, cp2_cp3, yPercent);
                Vector3 yy = Vector3.Lerp(cp0_cp2, cp1_cp3, xPercent);
                _vertices[i] = (xx + yy) * 0.5f;
            }
        }
        _meshFilter.mesh.vertices = _vertices;
    }

}
