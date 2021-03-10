using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beginGuidePhase2 : MonoBehaviour
{
    private string[] texts = new string[4];
    private bool[] isTextDisp = {true, false, false, false};
    private Text guide;

    void Start()
    {
        guide = GetComponent<Text>();
        texts[0] = $"Press {Inputs.InputArray[5]} to set sails, press again to stop";
        texts[1] = "Sharks are dumb, they eat crates, when you kill them they have a chance to drop loots";
        texts[2] = "Your food and water decreases over time, no water will kill you, no food will only make you really slow";
        texts[3] = $"Your boat have auto aim on sharks, press {Inputs.InputArray[6]} or {Inputs.InputArray[7]} when a shark is in range";
        guide.text = texts[0];
    }

    void Update()
    {
        if (Time.time >= 4f && !isTextDisp[1])
        {
            guide.text = texts[1];
            isTextDisp[1] = true;
        }
        if (Time.time >= 9f && !isTextDisp[2])
        {
            guide.text = texts[2];
            isTextDisp[2] = true;
        }
        if (Time.time >= 16f && !isTextDisp[3])
        {
            guide.text = texts[3];
            isTextDisp[3] = true;
        }
        if (Time.time >= 25f)
        {
            guide.text = "";
            Destroy(this);
        }        
    }
}
