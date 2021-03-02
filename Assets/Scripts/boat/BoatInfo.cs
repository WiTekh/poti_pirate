using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Inputs;
using UnityEngine.UI;

public class BoatInfo : MonoBehaviour
{
    private GameObject victory;
    private Slider helth;
    private int healthstag = 2;
    private int repairtime = 3;
    private float timerRepair;
    private float timer;
    private bool Fed;
    private bool Touched;
    private bool Repairing;
    private boatController boat;

    private void Start()
    {
        victory = GameObject.Find("Victory");
        victory.SetActive(false);
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
            Inventory.food += 10;
            Inventory.water += 20;
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

        // FOOD

        if (Inventory.food <= 0 && Fed == false)
        {
            Fed = true;
            boat.m_speed /= 4;
        }

        if (Inventory.food > 0 && Fed)
        {
            boat.m_speed *= 4;
            Fed = false;
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

    // VICTORY
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndZone"))
        {
            victory.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
