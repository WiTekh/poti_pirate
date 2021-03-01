using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Inputs;

public class boatShoot : MonoBehaviour
{
    private GameObject m_cannonBall;

    [SerializeField] private Transform m_leftShoot;
    [SerializeField] private Transform m_rightShoot;

    private void Start()
    {
        m_cannonBall = Resources.Load(Path.Combine("GameObjects", "cannonball")) as GameObject;
    }

    void Update()
    {
        bool l_l = Input.GetKey(InputArray[6]);
        bool l_r = Input.GetKey(InputArray[7]);
        
        if (l_l || l_r)
        {
            if (l_l)
            {
                InstantiateCanonball(m_leftShoot, true);
            }
            else
            {
                InstantiateCanonball(m_rightShoot, false);
            }
        }
    }

    void InstantiateCanonball(Transform p_parent, bool p_left)
    {
        GameObject l_insted = Instantiate(m_cannonBall, p_parent);
        l_insted.transform.parent = p_parent;
        l_insted.GetComponent<Rigidbody>().AddForce((p_left ? -p_parent.right : p_parent.right) * 25f, ForceMode.Impulse);
    }
}
