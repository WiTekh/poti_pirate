using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeZone : MonoBehaviour
{
    public GameObject confirm;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        GameObject l_collided = other.gameObject;
        if (l_collided.CompareTag("Player"))
        {
            confirm.SetActive(true);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            Player.GetComponent<new_TPS_Movement.new_TPS_Movement>().m_canMove = false;
        }
    }
}
