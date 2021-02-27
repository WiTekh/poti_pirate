using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime;
    public Text timer;

    void Start()
    {
        timer.text = startTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime <= 0)
        {
            Debug.Log("Game Over");
        }
        else
        {
            startTime -= Time.deltaTime;
        }
        timer.text = Mathf.Round(startTime).ToString();
    }
}
