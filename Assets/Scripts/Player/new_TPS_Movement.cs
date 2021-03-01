using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Inputs;

namespace new_TPS_Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class new_TPS_Movement : MonoBehaviour
    {
        [Header("Walk Settings")] public float walkSpeed;

        [Header("Camera Settings")] public Transform tpCam;

        private float m_xAxis;
        private float m_zAxis;
        private float m_currentSpeed;

        private float cantMoveTime = 2f;
        private float currentCD = 0f;
        
        private bool m_isMoving;
        public bool m_canMove;
        
        private Rigidbody m_rb;
        private animationStateController m_animController;

        private float m_turnSmoothVelocity;

        private void Awake()
        {
            m_canMove = true;
            m_animController = transform.GetChild(0).GetComponent<animationStateController>();
            tpCam = GameObject.Find("TPCam").transform;
            m_rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            #region controller Input [horizontal | vertical ] movement

            m_xAxis = Input.GetKey(InputArray[2]) ? -1 : Input.GetKey(InputArray[3]) ? 1 : 0;
            m_zAxis = Input.GetKey(InputArray[0]) ? 1 : Input.GetKey(InputArray[1]) ? -1 : 0;

            m_isMoving = m_zAxis != 0 || m_xAxis != 0;
            
            m_currentSpeed = m_isMoving ? walkSpeed : 0;

            //Passing Inputs as a Vector3

            //Debug.Log(new Vector3(m_xAxis, 0f, m_zAxis));

            #endregion
        }

        private void FixedUpdate()
        {
            //stopMoving if picking up
            if (Input.GetKey(InputArray[4])) {
                m_canMove = false;
            }
            
            if (m_canMove)
            {
                #region rotate player

                float l_targetAngle =
                    Mathf.Atan2(m_xAxis, m_zAxis) * Mathf.Rad2Deg +
                    tpCam.eulerAngles.y; // Compute the angle that faces the camera
                float l_angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, l_targetAngle, ref m_turnSmoothVelocity,
                    0.1f); // Smoothing the angle when we go from moving forwrd to strafing left

                transform.rotation =
                    m_isMoving ? Quaternion.Euler(0f, l_angle, 0f) : transform.rotation; // applying Rotation

                Vector3 l_moveDirection = Quaternion.Euler(0f, l_targetAngle, 0f) * Vector3.forward;

                #endregion

                #region move player

                //m_rb.MovePosition(transform.position + Time.deltaTime * walkSpeed *
                //transform.TransformDirection(m_xAxis, 0f, m_zAxis));

                m_rb.MovePosition(transform.position + l_moveDirection.normalized * Time.deltaTime * m_currentSpeed);

                #endregion
            }
            else
            {
                //reset Cooldown
                if (currentCD <= cantMoveTime)
                {
                    currentCD += Time.deltaTime;
                }
                else
                {
                    currentCD = 0f;
                    m_canMove = true;
                    m_animController.GetComponent<Animator>().SetBool("pickup", false);
                }
            }

            //Reset Visual's transform
            // (Only fix I found quickly enough to the animation reset position problem)
            // (Might be resources greedy)
            m_animController.m_rotation = transform.rotation;
            m_animController.m_position = transform.position;

        }

    }
}