using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Game2Manager : MonoBehaviour
{
    private static GameObject boat;
    public CinemachineFreeLook cinemachineCam;
    
    private int boat_choice = Inventory.monbato;

    private void Awake() 
    {
        switch (boat_choice)
        {
            case 0:
                boat = Instantiate(Resources.Load("military") as GameObject, transform);
                break;
            case 1:
                boat = Instantiate(Resources.Load("boat-fishing") as GameObject, transform);
                break;
            case 2:
                boat = Instantiate(Resources.Load("Boat") as GameObject, transform);
                break;
        }

        cinemachineCam.Follow = boat.transform;
        cinemachineCam.LookAt = boat.transform;
        
        proceduralGen.viewer = boat.transform;
    }
}
