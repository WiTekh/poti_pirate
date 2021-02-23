using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator m_animator;

    int isRunningHash;
    int pickUpHash;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        pickUpHash = Animator.StringToHash("pickup");
    }
    void Update()
    {
        bool l_forwardPressed = Input.GetKey("w");
        bool l_isEPressed = Input.GetKey("e");

        bool l_isRunning = m_animator.GetBool(isRunningHash);

        if (l_isEPressed)
        {
            m_animator.SetTrigger("pickup");
        }
        else
        {
           m_animator.ResetTrigger("pickup");
        }

        if (l_forwardPressed && !l_isRunning)
        {
            m_animator.SetBool(isRunningHash, true);
        }
        if (!l_forwardPressed && l_isRunning)
        {
            m_animator.SetBool(isRunningHash, false);
        }
    }
}
