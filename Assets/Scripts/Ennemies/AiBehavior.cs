using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehavior : MonoBehaviour
{ 
    private static Transform charo;
    public float speed = 2f;
    private float timer;
    public int life = 1;

    private void Start()
    {
        timer = 0;
        charo = GameObject.Find("military(Clone)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Target(transform.position, 20f);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Target(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, ~(1<<8));
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
