using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableManager))]
public abstract class Interactable : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField]
    protected string m_debugName = "debugName";


    [Space(20)]
    [Header("Variables")]
    [SerializeField]
    float m_coneAngle = 180.0f;

    bool m_playerInside = false;

    [SerializeField, Tooltip("higher is better")]
    int m_priotity = 0;



    public int Priotity { get => m_priotity; set => m_priotity = value; }


    public void OnEnter(PlayerController a_player)
    {
        m_playerInside = true;
        DebugPrint("PLayer Enter");
    }

    public void OnExit(PlayerController a_player)
    {
        m_playerInside = false;
        DebugPrint("PLayer Exit");
    }

    public void OnStay(PlayerController a_player)
    {
        //Debug.Log("PLayer Stay");
    }

    public virtual bool IsInteractable(PlayerController a_player)
    {

        Vector3 vecToMe = gameObject.transform.position - a_player.transform.position;
        float angle = Vector2.Angle(new Vector2(a_player.transform.forward.x, a_player.transform.forward.z), new Vector2(vecToMe.x, vecToMe.z));

        return angle <= m_coneAngle;
    }

    public virtual bool Interact(PlayerController a_player)
    {
        DebugPrint("Interact");
        return true;
    }

    protected virtual void Start()
    {
        
    }

    protected void DebugPrint(string a_message)
    {
        Debug.Log("["+ m_debugName + "] : " + a_message);
    }

}
