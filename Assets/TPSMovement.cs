using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class TPSMovement : MonoBehaviour
{
    public CharacterController m_controller;
    public float m_speed = 6;

    void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 l_movement = Vector3.zero;

        if (Input.GetKey(InputArray[0])){
            l_movement.z += 1;
        }
        if (Input.GetKey(InputArray[1])){
            l_movement.z -= 1;
        }

        if (Input.GetKey(InputArray[2])){
            l_movement.x -= 1;
        }
        if (Input.GetKey(InputArray[3])){
            l_movement.x += 1;
        }

        if (l_movement.magnitude >= 0.1f)
        {
            float l_targetAngle = Mathf.Atan2(l_movement.x, l_movement.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, l_targetAngle, 0f);

            m_controller.Move(l_movement * m_speed * Time.deltaTime);
        }

        Debug.Log(l_movement); 
    }
}
