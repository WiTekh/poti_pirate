using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class changeSensivity : MonoBehaviour
{
    private int prevSens;

    private void Start()
    {
        prevSens = Inputs.camSensivity;
    }

    private void Update()
    {
        if (gameObject.name == "CM FreeLook1")
        {
            if (Inputs.camSensivity != prevSens)
            {
                GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = Inputs.camSensivity;
                prevSens = Inputs.camSensivity;
            }
        }
        else
        {
            Debug.Log(Inputs.camSensivity);
        }
    }
    
    public void Change()
    {
        Inputs.camSensivity = (int)GetComponent<Slider>().value;
    }
}
