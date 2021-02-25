 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 [RequireComponent(typeof(MeshFilter))]
 [RequireComponent(typeof(MeshRenderer))]
 
public class WaterManager : MonoBehaviour
{
 private MeshFilter m_filter;

 private void Awake()
 {
  m_filter = GetComponent<MeshFilter>();
 }

 private void Update()
 {
  Vector3[] l_vertices = m_filter.mesh.vertices;
  for (int i = 0; i < l_vertices.Length; i++)
  {
   l_vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + l_vertices[i].x);
  }

  m_filter.mesh.vertices = l_vertices;
  m_filter.mesh.RecalculateNormals();
 }
}
