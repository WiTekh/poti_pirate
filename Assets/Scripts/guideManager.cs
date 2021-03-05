using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideManager : MonoBehaviour
{
    //Public variables
    [Header("Objects to show/unshow")]
    /*  0 - start   1 - food
        2 - water   3 - plank
        4 - cannonballs
     */
    public GameObject[] guides;
    public bool[] guidesSaw;

    [Header("Settings")]
    private float timeOnScreen;
    
    //Private variables
    public float currentTime = 0f;
    private bool guideShowing;
    private int guideShown;

    private void Start()
    {
        guidesSaw = new bool[guides.Length];
        ShowGuide(0, 5f);
        guidesSaw[0] = true;
    }

    private void Update()
    {
        if (guideShowing)
        {
            if (currentTime >= timeOnScreen)
            {
                guideShowing = false;
                guides[guideShown].SetActive(false);
                currentTime = 0f;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }

        if (Inventory.food == 1 && !guidesSaw[1])
        {
            ShowGuide(1);
        }

        if (Inventory.planks == 1 && !guidesSaw[3])
        {
            ShowGuide(3);
        }
        
        if (Inventory.cannonball >= 1 && !guidesSaw[4])
        {
            ShowGuide(4);
        }

    }

    public void ShowGuide(int guide, float customTime = 3f)
    {
        if (!guideShowing)
        {
            if (customTime != 3f)
                timeOnScreen = customTime;
            guideShowing = true;
            guideShown = guide;
            guides[guide].SetActive(true);
            guidesSaw[guide] = true;
        }
    }
}
