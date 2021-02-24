using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterNoise : MonoBehaviour
{
    public float m_power = 3f;
    public float m_scale = 1f;
    public float m_timeScale = 1f;

    private float m_OffsetX;
    private float m_OffsetY;
    private MeshFilter m_filter;

    void Start()
    {
        m_filter = GetComponent<MeshFilter>();
    }

    void Update()
    {
        ApplyNoise();
        m_OffsetX += Time.deltaTime * m_timeScale;
        m_OffsetY += Time.deltaTime * m_timeScale;
    }

    void ApplyNoise()
    {
        Vector3[] l_vertices = m_filter.mesh.vertices;

        for (int i = 0; i < l_vertices.Length; i++)
        {
            l_vertices[i].y = ComputeNoise(l_vertices[i].x, l_vertices[i].z) * m_power;
        }

        m_filter.mesh.vertices = l_vertices;
    }

    float ComputeNoise(float x, float y)
    {
        float l_xCoord = x * m_scale + m_OffsetX;
        float l_yCoord = y * m_scale + m_OffsetY;

        return Mathf.PerlinNoise(l_xCoord, l_yCoord);
    }
}
