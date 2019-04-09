using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField]
    Item m_item;


    bool m_isUsed;

    public override bool IsInteractable(PlayerController a_player)
    {
        return base.IsInteractable(a_player) && !m_isUsed;
    }


    public override bool Interact(PlayerController a_player)
    {
        bool res = base.Interact(a_player);

        a_player.Inventory.AddItem(m_item);

        m_isUsed = true;

        a_player.ResetInteractable();

        Destroy(gameObject);

        return res;
    }
}
