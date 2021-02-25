using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class lootPickup : MonoBehaviour
{
    void Update()
    {    
        DebugPickup(transform.position, 0.6f);
    }

    void DebugPickup(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius,~(1<<8));
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Pickup"))
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
                        case "Plank" :
                            Inventory.planks++;
                            break;
                    }
                    Destroy(hitCollider.gameObject);
                    Debug.Log("food = " + Inventory.food);
                }
            }
        }
    }
}
