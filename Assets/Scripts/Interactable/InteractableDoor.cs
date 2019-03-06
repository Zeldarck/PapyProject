using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{

    [SerializeField]
    bool m_isOpen;

    [SerializeField]
    Item m_key;

    public override bool IsInteractable(PlayerController a_player)
    {
        return base.IsInteractable(a_player) && a_player.Inventory.HasItem(m_key) && !m_isOpen;
    }

    public override bool Interact(PlayerController a_player)
    {
        bool res = base.Interact(a_player);

        if (!m_isOpen)
        {
            a_player.Inventory.RemoveItem(m_key);
            m_isOpen = true;
        }

        if (res)
        {
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }


        a_player.ResetInteractable();

        return res;
    }


}
