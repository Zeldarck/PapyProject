using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{

    [SerializeField]
    bool m_isOpen;

    [SerializeField]
    bool m_isLock;
    [SerializeField]
    Item m_key;

    public override bool IsInteractable(PlayerController a_player)
    {
        return base.IsInteractable(a_player) && ((a_player.Inventory.HasItem(m_key) && m_isLock) || !m_isLock);
    }

    public override bool Interact(PlayerController a_player)
    {
        bool res = base.Interact(a_player);

        if (m_isLock)
        {
            a_player.Inventory.UseItem(m_key);
            
            m_isLock = false;
            DebugPrint("Unlock");
        }

        if (m_isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }

        a_player.ResetInteractable();

        return res;
    }

    void Open()
    {
        DebugPrint("Open");
        transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        m_isOpen = true;
    }

    void Close()
    {
        DebugPrint("Close");
        transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        m_isOpen = false;
    }


}
