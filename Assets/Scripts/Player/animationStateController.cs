using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class animationStateController : MonoBehaviour
{
    public new_TPS_Movement.new_TPS_Movement PlayerMovement;
    Animator m_animator;

    private int isRunningHash;
    private int pickUpHash;
    private int canMoveHash;

    [HideInInspector] public Quaternion m_rotation;
    [HideInInspector] public Vector3 m_position;

    private const int m_time = 2;
    private float m_currentTime = 0f;

    //public bool isPickup;
    
    void Start()
    {
        m_animator = GetComponent<Animator>();
        
        isRunningHash = Animator.StringToHash("isRunning");
        canMoveHash = Animator.StringToHash("canMove");
        pickUpHash = Animator.StringToHash("pickup");
    }
    void Update()
    {
        bool moveInput = Input.GetKey(InputArray[0]) || Input.GetKey(InputArray[1]) || Input.GetKey(InputArray[2]) || Input.GetKey(InputArray[3]);
        bool pickupInput = Input.GetKey(InputArray[4]);
        
        bool runAnim = m_animator.GetBool(isRunningHash);


        if (moveInput)
        {
            if (PlayerMovement.m_canMove)
            {
                m_animator.SetBool(isRunningHash, true);
            }
            else if (runAnim)
            {
                m_animator.SetBool(isRunningHash, false);
            }
        }
        else
        {
            if (runAnim)
            {
                m_animator.SetBool(isRunningHash, false);
            }
        }

        if (pickupInput && !m_animator.GetBool(pickUpHash))
        {
            Debug.Log("yo");
            m_animator.SetBool(pickUpHash, true);
        }
        
        //Reset Position/Rotation
        if (transform.position.magnitude >= 0.1f){
            transform.position = m_position;
        }
        if (Mathf.Abs(transform.rotation.y) >= 0.1f){
            transform.rotation = m_rotation;
        }
    }
}
