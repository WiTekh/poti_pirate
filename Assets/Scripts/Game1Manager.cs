using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Game1Manager : MonoBehaviour
{
    private static GameObject player;
    public GameObject boat;
    private escapeZone m_escapeZone;
    
    public CinemachineFreeLook cinemachineCam;
    
    //private int boat_choice = Inventory.monbato;

    private void Awake()
    {
        boat = GameObject.Find("boat_prefabs");
        m_escapeZone = GameObject.Find("EscapeZone").GetComponent<escapeZone>();
        
        player = Instantiate(Resources.Load("player") as GameObject, transform);
        
        boat.transform.GetChild(Inventory.monbato).gameObject.SetActive(true);
        m_escapeZone.Player = player;
        
        cinemachineCam.Follow = player.transform;
        cinemachineCam.LookAt = player.transform;
        
        proceduralGen.viewer = player.transform;
        
    }
}