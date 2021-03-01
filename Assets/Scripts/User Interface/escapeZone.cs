using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeZone : MonoBehaviour
{
    public GameObject confirm;
    public GameObject Player;

    public bool Transitionning;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transitionning = true;
            confirm.SetActive(true);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            Player.GetComponent<new_TPS_Movement.new_TPS_Movement>().m_canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transitionning = false;
        }
    }
}
