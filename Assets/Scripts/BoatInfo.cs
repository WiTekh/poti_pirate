using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoatInfo : MonoBehaviour
{
    public Slider helth;
    private int healthstag = 2;
    private float timer;
    private bool Touched = false;

    private void Start()
    {
        timer = 0;
        helth = GameObject.Find("boatHealth").GetComponent<Slider>();
    }

    private void Update()
    {
        if (Touched)
        {
            timer += Time.deltaTime;
            if (timer >= healthstag)
            {
                Touched = false;
                timer = 0;
            }
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
