using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startTime;
    public Text timer;

    public GameObject m_DeathPanel;

    void Start()
    {
        m_DeathPanel.SetActive(false);
        timer.text = startTime.ToString();
    }

    void Update()
    {
        if (startTime <= 0)
        {
            
            if (Inventory.isSafe)
            {
                //Go to phase 2
                //Reset 'Game1' Scene somehow
                SceneManager.LoadScene("Game2");
            }
            else
            {
                Inventory.isDed = true;
                Time.timeScale = 0f;
                m_DeathPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                //GameOver
            }
        }
        else
        {
            startTime -= Time.deltaTime;
        }
        //timer.text = Mathf.Round(startTime).ToString();
        timer.text = $"{Mathf.Floor(startTime / 60f)}:{Mathf.Floor(startTime % 60)}";

    }
}
