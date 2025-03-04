﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class lootPickup : MonoBehaviour
{
    private float tictac = 0;
    private bool PickupAct = true;

    private GameObject guide;
    private bool first = true;

    private void Start()
    {
        guide = GameObject.Find("Guide");
    }

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
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f, ~(1 << 8));

        if (hitColliders.Length > 1)
        {
            Pickup(hitColliders);
        }
    }

    void Pickup(Collider[] overlapColl)
    {
        if (overlapColl.Length != 0)
        {
            foreach (var hitCollider in overlapColl)
            {
                if (hitCollider.CompareTag("Pickup"))
                {
                    if (PickupAct)
                    {
                        if (Input.GetKeyDown(InputArray[4]))
                        {
                            switch (hitCollider.gameObject.name)
                            {
                                case "Apple":
                                case "Banana":
                                    Inventory.food++;
                                    break;
                                case "Treasure":
                                    Inventory.treasure = true;
                                    break;
                                case "Cannonball":
                                    Inventory.cannonball++;
                                    break;
                                case "Cannonballs":
                                    Inventory.cannonball += 3;
                                    break;
                                case "Plank":
                                    Inventory.planks++;
                                    break;
                                case "Planks":
                                    Inventory.planks += 3;
                                    break;
                            }

                            Destroy(hitCollider.gameObject);
                            PickupAct = false;
                        }
                    }
                }

                if (hitCollider.CompareTag("WaterZone"))
                {
                    if (first)
                    {
                        guideManager gM = guide.GetComponent<guideManager>();
                        gM.ShowGuide(2);
                        first = false;
                    }

                    if (PickupAct)
                    {
                        if (Input.GetKeyDown(InputArray[4]))
                        {
                            Inventory.water += 2;
                            PickupAct = false;
                        }
                    }
                }
            }
        }
    }
}
