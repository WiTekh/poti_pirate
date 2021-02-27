using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class lootPickup : MonoBehaviour
{
    public float cooldown = 3f;
    private float tictac = 0;
    private bool PickupAct = true;

    void Update()
    {
        if (tictac > cooldown)
        {
            Debug.Log("STOP");
            PickupAct = true;
            tictac = 0;
        }
        
        if (PickupAct == false)
        {
            Debug.Log("No : " + tictac);
            tictac += Time.deltaTime;
        }

        if (PickupAct)
        {
            Debug.Log("YES");
        }
        Pickup(transform.position, 2f);
    }

    void Pickup(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius,~(1<<8));
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Pickup"))
            {
                if (PickupAct)
                {
                    if (Input.GetKeyDown(InputArray[4]))
                    {
                        switch (hitCollider.gameObject.name)
                        {
                            case "Banana" :
                                Inventory.food++;
                                break;
                            case "Coconut" :
                                Inventory.food++;
                                break;
                            case "Treasure" :
                                Inventory.treasure = true;
                                break;
                            case "Cannonball" :
                                Inventory.cannonball++;
                                break;
                            case "Cannonballs" :
                                Inventory.cannonball+=4;
                                break;
                            case "Plank" :
                                Inventory.planks++;
                                break;
                            case "Planks" :
                                Inventory.planks+=6;
                                break;
                        }
                        Destroy(hitCollider.gameObject);
                        PickupAct = false;
                    }
                }
            }

            if (hitCollider.CompareTag("WaterZone"))
            {
                if (PickupAct)
                {
                    if (Input.GetKeyDown(InputArray[4]))
                    {
                        Inventory.water++;
                        PickupAct = false;
                    }
                }
            }
        }
    }
}
