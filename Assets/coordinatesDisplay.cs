using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coordinatesDisplay : MonoBehaviour
{
    private bool getEndCo = true;
    private Vector3 endSpawn;
    private Transform boatTransform;

    private void Start()
    {
        boatTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (getEndCo)
        {
            endSpawn = proceduralGen.computedSP;
            getEndCo = false;
        }

        float playerX = boatTransform.position.x;
        float playerZ = boatTransform.position.z;

        string UIText = $"{Format(playerX, "x")}\ny :    0\n{Format(playerZ, "z")}\nGoal   :\n{Format(endSpawn.x, "x")}\ny :    0\n{Format(endSpawn.z, "z")}";
        GetComponent<Text>().text = UIText;
    }

    private string Format(float pos, string axis)
    {
        string posString = Mathf.Round(pos).ToString();
        for (int i = posString.Length; i < 5; i++)
        {
            posString = " " + posString;
        }

        return $"{axis} :{posString}";
    }
}
