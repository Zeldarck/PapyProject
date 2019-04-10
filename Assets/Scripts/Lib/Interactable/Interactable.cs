using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableManager))]
[RequireComponent(typeof(ObjectIdentityHandler))]
public abstract class Interactable : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField]
    protected string m_debugName = "";


    [Space(20)]
    [Header("Variables")]
    [SerializeField]
    float m_coneAngle = 180.0f;

    bool m_playerInside = false;

    [SerializeField, Tooltip("higher is better")]
    int m_priotity = 0;

    [SerializeField]
    Condition m_condition;

    [SerializeField]
    protected InteractableUI m_InteractableUIPrefab;

    [SerializeField]
    Vector3 m_UIOffset = new Vector3(0, 3, 0);


    protected InteractableUI m_InteractableUI;


    protected ObjectIdentityHandler m_identity;



    public int Priotity { get => m_priotity; set => m_priotity = value; }


    public virtual void OnEnter(PlayerController a_player)
    {
        m_playerInside = true;
        m_InteractableUI.Display(true);
        DebugPrint("PLayer Enter");
    }

    public virtual void OnExit(PlayerController a_player)
    {
        m_playerInside = false;
        m_InteractableUI.Display(false);
        DebugPrint("PLayer Exit");
    }

    public virtual void OnStay(PlayerController a_player)
    {
        //Debug.Log("PLayer Stay");
    }

    public virtual bool IsInteractable(PlayerController a_player)
    {

        Vector3 vecToMe = gameObject.transform.position - a_player.transform.position;
        float angle = Vector2.Angle(new Vector2(a_player.transform.forward.x, a_player.transform.forward.z), new Vector2(vecToMe.x, vecToMe.z));

        return angle <= m_coneAngle && m_condition.Execute();
    }

    public virtual bool Interact(PlayerController a_player)
    {
        DebugPrint("Interact");
        return true;
    }

    protected virtual void Start()
    {
        m_identity = GetComponent<ObjectIdentityHandler>();

        GameObject interactableUI = Instantiate(m_InteractableUIPrefab.gameObject, transform.position + m_UIOffset, Quaternion.identity);
        interactableUI.transform.SetParent(transform);
        m_InteractableUI = interactableUI.GetComponent<InteractableUI>();
        m_InteractableUI.Display(false);

#if UNITY_EDITOR
        if (m_debugName == "")
        {
            m_debugName = m_identity.GetName();
        }
#endif
    }

    protected virtual void Update()
    {

    }


    protected void DebugPrint(string a_message)
    {
        Debug.Log("["+ m_debugName + "] : " + a_message);
    }

}
