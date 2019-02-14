using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;



public class PlayerController : MonoBehaviour
{

    NavMeshAgent agent;

    [SerializeField]
    float m_speed;


    void Start () {
        agent = GetComponent<NavMeshAgent>();
        Camera.main.GetComponent<CameraFollow>().ObjectToFollow = gameObject;
        //agent.speed = m_speed;   
    }

    void Update () {

        bool isMoving = false;
        Vector3 target = transform.position;

        if (Input.GetKey(KeyCode.Z))
        {
            target += gameObject.transform.forward * m_speed;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            target += gameObject.transform.right * -1 * m_speed;
            isMoving = true;
        }
       /* if (Input.GetKey(KeyCode.S))
        {
            target += gameObject.transform.forward * -1 * m_speed;
            isMoving = true;
        }*/
        if (Input.GetKey(KeyCode.D))
        {
            target += gameObject.transform.right * m_speed;
            isMoving = true;
        }

        if (isMoving)
        {
            agent.ResetPath();
        }

        if (Input.GetButtonDown("Fire2") && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
                isMoving = true;
            }
        }


        if (isMoving)
        {
            agent.SetDestination(target);
        }


    }
}
