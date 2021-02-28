using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Inventory;

public class UIUpdate : MonoBehaviour
{
    [Header("UI to update")] 
    public Text foodText;
    public Text waterText;
    public Text plankText;
    public Text canonballText;
    public GameObject treasure;

    private void Start()
    {
        this.treasure.SetActive(false);
    }

    void Update()
    {
        foodText.text = food.ToString();
        waterText.text = water.ToString();
        plankText.text = planks.ToString();
        if (canonballText != null) 
            canonballText.text = cannonball.ToString();
        
        if (Inventory.treasure)
            this.treasure.SetActive(true);
    }
}
