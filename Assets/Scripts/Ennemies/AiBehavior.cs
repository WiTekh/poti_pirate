using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AiBehavior : MonoBehaviour
{ 
    private Transform charo;
    public float speed = 2f;
    private float timer;
    public int life = 1;
    private Random rand;
    private int chance;

    private void Start()
    {
        rand = new Random();
        timer = 0;
        charo = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Target();
        if (life <= 0)
        {
            chance = rand.Next(3);
            if (chance == 1)
            {
                Debug.Log("poof");
                Instantiate(Resources.Load("crate-box-traingle"), transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    void Target()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 30f, ~(1<<8));

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                transform.position = Vector3.MoveTowards(transform.position, charo.position, speed * Time.deltaTime);
                Vector3 direction = transform.position - charo.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime) ;
            }
        }
    }
}
