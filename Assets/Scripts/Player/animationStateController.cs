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

    private const int m_time = 3;
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
        //isPickup = m_animator.GetBool(pickUpHash);
        
        if (m_animator.GetBool(pickUpHash))
        {
            if (m_currentTime < m_time)
            {
                m_currentTime += Time.deltaTime;
            }
            else
            {
                m_animator.SetBool(pickUpHash, false);
            }
        }
        
        if (m_animator.GetBool(pickUpHash) != PlayerMovement.m_canMove)
            m_animator.SetBool(canMoveHash, PlayerMovement.m_canMove);
        
        bool l_forwardPressed = Input.GetKey(InputArray[0]) || Input.GetKey(InputArray[1]) || Input.GetKey(InputArray[2]) || Input.GetKey(InputArray[3]);
        bool l_isEPressed = Input.GetKey(InputArray[4]);

        bool l_isRunning = m_animator.GetBool(isRunningHash);

        if (l_isEPressed)
        {
            m_animator.SetBool(pickUpHash, true);
        }

        if (l_forwardPressed && !l_isRunning)
        {
            m_animator.SetBool(isRunningHash, true);
        }
        if (!l_forwardPressed && l_isRunning)
        {
            m_animator.SetBool(isRunningHash, false);
        }

        if (transform.position.magnitude >= 0.01f){
            transform.position = m_position;
        }
        if (Mathf.Abs(transform.rotation.y) >= 0.01f){
            transform.rotation = m_rotation;
        }
        
    }
}
