using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inputs;

public class animationStateController : MonoBehaviour
{
    Animator m_animator;

    int isRunningHash;
    int pickUpHash;

    [HideInInspector] public Quaternion m_rotation;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        pickUpHash = Animator.StringToHash("pickup");
    }
    void Update()
    {
        bool l_forwardPressed = Input.GetKey(InputArray[0]) || Input.GetKey(InputArray[1]) || Input.GetKey(InputArray[2]) || Input.GetKey(InputArray[3]);
        bool l_isEPressed = Input.GetKey(InputArray[4]);

        bool l_isRunning = m_animator.GetBool(isRunningHash);

        if (l_isEPressed)
        {
            m_animator.SetTrigger(pickUpHash);
        }
        else
        {
           m_animator.ResetTrigger(pickUpHash);
        }

        if (l_forwardPressed && !l_isRunning)
        {
            m_animator.SetBool(isRunningHash, true);
        }
        if (!l_forwardPressed && l_isRunning)
        {
            m_animator.SetBool(isRunningHash, false);
        }

        if (Mathf.Abs(transform.position.y) >= 0.01f){
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }
        if (Mathf.Abs(transform.rotation.y) >= 0.01f){
            transform.rotation = m_rotation;
        }
    }
}
