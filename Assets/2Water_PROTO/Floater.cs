using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody m_rigidBody;
    public float m_depthBeforeSubmerged;
    public float m_displacementAmount;

    public int m_floaterCount = 1;

    public float m_waterDrag = 0.99f;
    public float m_waterAngularDrag = 0.5f;

    public float phaseX;


    private void FixedUpdate()
    {
        m_rigidBody.AddForceAtPosition(Physics.gravity / m_floaterCount, transform.position, ForceMode.Acceleration 
        );
        float l_waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x, transform.position.z);
        
        if (transform.position.y < l_waveHeight )
        {
            float l_displacementMultiplier = Mathf.Clamp01((l_waveHeight - transform.position.y) / m_depthBeforeSubmerged) * m_displacementAmount;
            m_rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * l_displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            m_rigidBody.AddForce(l_displacementMultiplier * -m_rigidBody.velocity * m_waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            m_rigidBody.AddTorque(l_displacementMultiplier * -m_rigidBody.angularVelocity * m_waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
