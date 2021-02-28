using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehavior : MonoBehaviour
{ 
    [SerializeField] Transform charo;
    public float speed = 2f;
    public int life = 1;
    
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
               transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            life--;
        }
    }
}
