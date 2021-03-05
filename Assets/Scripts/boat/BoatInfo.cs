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

    private float timerfood = 8f; 
    private float timerwater = 7f;
    
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

        if (Inventory.food > 0)
        {
            timerfood -= Time.deltaTime;
        }

        if (timerfood <= 0)
        {
            timerfood = 8f;
            Inventory.food--;
        }
        
        if (Inventory.food <= 0 && Fed == false)
        {
            Fed = true;
            boat.m_speed = 2;
        }

        if (Inventory.food > 0 && Fed)
        {
            boat.m_speed = 5;
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
        // LIFE

        if (helth.value <= 0)
        {
            GameOver();
        }
        
        // WATER

        if (Inventory.water <= 0)
        {
            GameOver();    
        }
        
        if (Inventory.water > 0)
        {
            timerwater -= Time.deltaTime;
        }

        if (timerwater <= 0)
        {
            timerwater = 7f;
            Inventory.water--;
        }
    }

    // GAME OVER

    private void GameOver()
    {
        Debug.Log("You lost");
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
        
        if(other.CompareTag("Crate"))
        {
            Inventory.planks += 4;
            Inventory.food += 3;
            Inventory.cannonball += 4;
            Inventory.water += 3;
            Destroy(other.gameObject);
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
