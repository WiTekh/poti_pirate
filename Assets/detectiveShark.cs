using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectiveShark : MonoBehaviour
{
    public GameObject leWequin = null;
    private void OnTriggerEnter(Collider bowser)
    {
        Debug.Log("ananas grille");
        if (bowser.CompareTag("Ennemy"))
        {
            leWequin = bowser.gameObject;
        }
    }
}
