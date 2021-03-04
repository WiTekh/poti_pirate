using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class lootPickup : MonoBehaviour
{
    private float tictac = 0;
    private bool PickupAct = true;

    private GameObject guide;
    private bool first = false;

    void Update()
    {
        if (tictac > 2f)
        {
            PickupAct = true;
            tictac = 0;
        }
        
        if (!PickupAct)
        {
            tictac += Time.deltaTime;
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
                            case "Apple" :
                            case "Banana" :
                                Inventory.food++;
                                break;
                            case "Treasure" :
                                Inventory.treasure = true;
                                break;
                            case "Cannonball" :
                                Inventory.cannonball++;
                                break;
                            case "Cannonballs" :
                                Inventory.cannonball+=3;
                                break;
                            case "Plank" :
                                Inventory.planks++;
                                break;
                            case "Planks" :
                                Inventory.planks+=3;
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
                        Inventory.water+=2;
                        PickupAct = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (first)
        {
            guideManager gM = guide.GetComponent<guideManager>();
            gM.ShowGuide(2);
            first = false;
        }
    }
}
