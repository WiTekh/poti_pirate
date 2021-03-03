using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSettings : MonoBehaviour
{
    private bool waitngForInput = false;
    private int pos;
    private void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Inputs.InputArray[i].ToString();
        }

        if (waitngForInput)
        {
            if (Input.inputString.Length <= 0) return;
            string inputo = Input.inputString[0].ToString();
            
            Inputs.InputArray[pos] = (KeyCode) Enum.Parse(typeof(KeyCode), inputo);
            waitngForInput = false;
        }
    }

    public void ChangeInput(int pos)
    {
        waitngForInput = true;
        this.pos = pos;
    }
}
