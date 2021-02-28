using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Manager : MonoBehaviour
{
    private static GameObject boat;
    private int boat_choice = Inventory.monbato; 
    
    private void Awake()
    {
        switch (boat_choice)
        {
            case 0 :
                boat = Instantiate(Resources.Load("military") as GameObject, transform.position, Quaternion.identity);
                break;
            case 1 :
                boat = Instantiate(Resources.Load("boat-fishing") as GameObject, transform.position, Quaternion.identity);
                break;
            case 2 :
                boat = Instantiate(Resources.Load("Boat") as GameObject, transform.position, Quaternion.identity);
                break;
        }
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
