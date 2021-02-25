using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;
    
    public static WaveManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += speed * Time.deltaTime;
    }

    public float GetWaveHeight(float x, float z)
    {
        float X = x / length + offset;
        float Z = z / length + offset;

        return amplitude * Mathf.Cos(X) * Mathf.Sin(Z) * Mathf.PerlinNoise(X, Z);
    }
}
