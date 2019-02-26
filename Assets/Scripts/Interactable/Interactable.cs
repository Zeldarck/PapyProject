using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableManager))]
public abstract class Interactable : MonoBehaviour
{

    [SerializeField]
    float m_coneAngle = 180.0f;

    bool m_playerInside = false;

    [SerializeField, Tooltip("higher is better")]
    int m_priotity = 0;

    [Header("Debug")]
    [SerializeField]
    string m_debugName = "debugName";


    public int Priotity { get => m_priotity; set => m_priotity = value; }


    public void OnEnter(PlayerController a_player)
    {
        m_playerInside = true;
        Debug.Log("PLayer Enter " + m_debugName);
    }

    public void OnExit(PlayerController a_player)
    {
        m_playerInside = false;
        Debug.Log("PLayer Exit " + m_debugName);
    }

    public void OnStay(PlayerController a_player)
    {
        //Debug.Log("PLayer Stay");
    }

    public bool IsInteractable(PlayerController a_player)
    {

        Vector3 vecToMe = gameObject.transform.position - a_player.transform.position;
        float angle = Vector2.Angle(new Vector2(a_player.transform.forward.x, a_player.transform.forward.z), new Vector2(vecToMe.x, vecToMe.z));

        return angle <= m_coneAngle;
    }

}
