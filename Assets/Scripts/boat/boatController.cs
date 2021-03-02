using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class boatController : MonoBehaviour
{
    [SerializeField] private bool m_isMoving;
    public float m_speed;
    [SerializeField] private float m_rotateSpeed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Instantiate(Resources.Load("waterPlane"));
        }
        
        if (Input.GetKeyDown(InputArray[5]))
        {
            m_isMoving = !m_isMoving;
        }

        if (m_isMoving)
        {
            transform.position += transform.forward * m_speed * Time.deltaTime;
        }
        
        Vector3 l_rotation = new Vector3(0f, Input.GetAxisRaw("Horizontal"), 0f);

        if (Mathf.Abs(l_rotation.magnitude) >= 0.1f)
        {
            transform.Rotate(l_rotation * Time.deltaTime * m_rotateSpeed, Space.Self);
        }
    }
}
