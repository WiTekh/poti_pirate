using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Inputs;
using UnityEngine.UI;

public class BoatInfo : MonoBehaviour
{
    private Slider helth;
    private int healthstag = 2;
    private int repairtime = 3;
    private float timerRepair;
    private float timer;
    private bool Touched;
    private bool Repairing;
    private boatController boat;

    private void Start()
    {
        boat = GetComponent<boatController>();
        timer = 0;
        timerRepair = 0;
        helth = GameObject.Find("boatHealth").GetComponent<Slider>();
    }

    private void Update()
    {
        // CHEAT CODES //

        if (Input.GetKeyDown(KeyCode.P))
        {
            Inventory.planks += 5;
            Inventory.cannonball += 10;
        }


        if (Touched)
        {
            timer += Time.deltaTime;
            if (timer >= healthstag)
            {
                Touched = false;
                timer = 0;
            }
        }

        // REPAIR
        if (Input.GetKeyDown(InputArray[8]) && Inventory.planks > 0 && Repairing == false)
        {
            Inventory.planks--;
            helth.value++;
            boat.m_speed /= 2;
            Repairing = true;
        }
        
        if (timerRepair >= repairtime)
        {
            Repairing = false;
            boat.m_speed *= 2;
            timerRepair = 0;
        }

        if (Repairing)
        {
            timerRepair += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndZone"))
        {
            Debug.Log("Victory");
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ennemy") && Touched == false)
        {
            Touched = true;
            helth.value--;
        }
    }
}
