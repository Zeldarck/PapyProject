using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField]
    Item m_item;

    public override bool Interact(PlayerController a_player)
    {
        bool res = base.Interact(a_player);

        a_player.Inventory.AddItem(m_item);

        a_player.ResetInteractable();

        Destroy(gameObject);

        return res;
    }
}
