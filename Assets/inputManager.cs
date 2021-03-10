using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputManager : MonoBehaviour
{
    private bool waitingForInput;

    private Text buttonText;
    private Event keyEvent;
    private KeyCode recordedKey;
    
    private void Start()
    {
        waitingForInput = false;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponentInChildren<Text>().text = Inputs.InputArray[i].ToString();
        }
    }

    private void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingForInput)
        {
            recordedKey = keyEvent.keyCode;
            waitingForInput = false;
        }
    }

    public void StartAssignment(int keyIndex)
    {
        if (!waitingForInput)
            StartCoroutine(AssignKey(keyIndex));
    }

    public void UpdateText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitforInput()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(int keyIndex)
    {
        waitingForInput = true;

        yield return WaitforInput();

        Inputs.InputArray[keyIndex] = recordedKey;
        buttonText.text = Inputs.InputArray[keyIndex].ToString();

        yield return null;
    }
}
