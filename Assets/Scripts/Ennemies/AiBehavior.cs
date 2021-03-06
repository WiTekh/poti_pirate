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
    private bool boolo;

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
            Debug.Log(chance);
            if (chance == 1)
            {
                Instantiate(Resources.Load("crate-box-traingle"), transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        if (!boolo)
            Move();
    }

    void Move()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
        transform.Rotate(new Vector3(0f, 1f, 0f));
    }
    
    void Target()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 30f, ~(1<<8));

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                boolo = true;
                transform.position = Vector3.MoveTowards(transform.position, charo.position, speed * Time.deltaTime);
                Vector3 direction = transform.position - charo.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime) ;
            }
        }
    }
}
