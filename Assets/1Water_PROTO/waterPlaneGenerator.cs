using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterPlaneGenerator : MonoBehaviour
{
    public float m_size = 1.0f;
    public int m_gridSize = 16;

    private MeshFilter m_filter;

    private void Start()
    {
        m_filter = GetComponent<MeshFilter>();
        m_filter.mesh = GenerateMesh();
    }

    private Mesh GenerateMesh()
    {
        Mesh l_mesh = new Mesh();

        var l_vertices = new List<Vector3>();
        var l_normals = new List<Vector3>();
        var l_UVs = new List<Vector2>();

        for (int x = 0; x < m_gridSize + 1; x++)
        {
            for (int y = 0; y < m_gridSize + 1; y++)
            {
                l_vertices.Add(new Vector3((-m_size * 0.5f+ m_size * (x / (float)m_gridSize)), 0, -m_size * 0.5f+ m_size * (y / (float)m_gridSize)));
                l_normals.Add(Vector3.up);
                l_UVs.Add(new Vector2(x / (float)m_gridSize, y / (float)m_gridSize));
            }
        }


        var l_triangles = new List<int>();
        var l_vertCount = m_gridSize + 1;

        for (int i = 0; i < l_vertCount * l_vertCount - l_vertCount; i++)
        {
            if ((i+1)%l_vertCount == 0)
            {
                continue;
            }
            l_triangles.AddRange(new List<int>() {
                i+1+l_vertCount, i+l_vertCount, i,
                i, i+1, i+l_vertCount+1
            });
        }

        l_mesh.SetVertices(l_vertices);
        l_mesh.SetNormals(l_normals);
        l_mesh.SetUVs(0, l_UVs);
        l_mesh.SetTriangles(l_triangles, 0);

        return l_mesh;
    }
}
