using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIColliders : MonoBehaviour
{
    private AiBehavior shark;
    private float timer;
    private bool Touched;

    private void Start()
    {
        shark = transform.parent.GetComponent<AiBehavior>();
    }

    private void Update()
    {
        if (Touched)
        {
            timer += Time.deltaTime;
        }

        if (timer >=2f && timer <= 2.1f)
        {
            shark.speed++;
        }

        if (timer >= 4f)
        {
            shark.speed++;
            timer = 0;
            Touched = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shark.speed = 1;
            Touched = true;
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            shark.life--;
        }
    }
}
