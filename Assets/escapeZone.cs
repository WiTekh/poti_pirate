using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeZone : MonoBehaviour
{
    public GameObject confirm;
    private void OnTriggerEnter(Collider other)
    {
        GameObject l_collided = other.gameObject;
        if (l_collided.CompareTag("Player"))
        {
            confirm.SetActive(true);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
