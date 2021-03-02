using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Inputs;

public class boatShoot : MonoBehaviour
{
    private GameObject m_cannonBall;
    private bool Shot;
    private int shoot_time = 1;
    private float timer;
    [SerializeField] private Transform m_leftShoot;
    [SerializeField] private Transform m_rightShoot;

    private void Start()
    {
        timer = 0;
        m_cannonBall = Resources.Load(Path.Combine("GameObjects", "cannonball")) as GameObject;
    }

    void Update()
    {
        if (Shot)
        {
            timer += Time.deltaTime;
        }

        if (timer >= shoot_time)
        {
            timer = 0;
            Shot = false;
        }
        bool l_l = Input.GetKey(InputArray[6]);
        bool l_r = Input.GetKey(InputArray[7]);
        
        if (l_l && Inventory.cannonball > 0  && Shot == false || l_r && Inventory.cannonball > 0 && Shot == false)
        {
            Shot = true;
            if (l_l)
            {
                Inventory.cannonball--;
                InstantiateCanonball(m_leftShoot, true);
            }
            else
            {
                Inventory.cannonball--;
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
