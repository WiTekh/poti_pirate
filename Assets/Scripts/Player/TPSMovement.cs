using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class TPSMovement : MonoBehaviour
{
    private Rigidbody m_rb;
    public Transform m_camera;
    private animationStateController m_animController;
    //private CharacterController m_controller;

    public float m_speed = 6;
    private const float m_gravity = 9.81f;
    
    float turnSmoothVelocity;

    void Start()
    {
        //Getting controller from this GO
        m_rb = GetComponent<Rigidbody>();
        //m_controller = GetComponent<CharacterController>();
        m_animController = transform.GetChild(0).GetComponent<animationStateController>();
    }

    void Update()
    {
        Vector3 l_movement = Vector3.zero;

        //Passing Inputs as a Vector3
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

        //Computing the movement vector
        if (l_movement.magnitude >= 0.1f)
        {
            float l_targetAngle = Mathf.Atan2(l_movement.x, l_movement.z) * Mathf.Rad2Deg + m_camera.eulerAngles.y; // Compute the angle that faces the camera
            float l_angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, l_targetAngle, ref turnSmoothVelocity, 0.1f); // Smoothing the angle when we go from moving forwrd to strafing left

            transform.rotation = Quaternion.Euler(0f, l_angle, 0f); // applying Rotation

            Vector3 l_moveDirection = Quaternion.Euler(0f, l_targetAngle, 0f) * Vector3.forward;

            //m_controller.Move(l_moveDirection.normalized * m_speed * Time.deltaTime); //Apply movements
        }

        // Synchronize rotation of Visual
        // (Only fix I found quickly enough to the animation reset position problem)
        // (Might be ressources greedy)
        m_animController.m_rotation = transform.rotation;
    }
}
