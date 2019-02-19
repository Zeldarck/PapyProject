using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [SerializeField]
    float m_coneAngle = 180.0f;

    bool m_playerInside = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 vecToMe = gameObject.transform.position - other.transform.position;
            float angle = Vector2.Angle( new Vector2(other.transform.forward.x,other.transform.forward.z) , new Vector2(vecToMe.x, vecToMe.z));

            if(angle <= m_coneAngle )
            {
                if (!m_playerInside)
                {
                    OnEnter(other.gameObject);
                }
                else
                {
                    OnStay(other.gameObject);
                }
            }
            else if (m_playerInside)
            {
                Debug.Log("Bad angle : " + angle + " compare to " + m_coneAngle);
                OnExit(other.gameObject);
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && m_playerInside)
        {
            OnExit(other.gameObject);
        }
    }


    protected void OnEnter(GameObject a_player)
    {
        m_playerInside = true;
        Debug.Log("PLayer Enter");
    }

    protected void OnExit(GameObject a_player)
    {
        m_playerInside = false;
        Debug.Log("PLayer Exit");
    }

    protected void OnStay(GameObject a_player)
    {
        //Debug.Log("PLayer Stay");
    }


}
