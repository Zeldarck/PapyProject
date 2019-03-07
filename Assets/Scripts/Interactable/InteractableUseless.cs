using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUseless : Interactable
{

    [SerializeField]
    GameObject m_pannel;

    PlayerController m_player;
    bool m_isActive;

    public override bool Interact(PlayerController a_player)
    {
        a_player.Freeze = true;
        m_player = a_player;
        m_pannel.SetActive(true);
        m_isActive = true;

        return base.Interact(a_player);
    }

    protected override void Update()
    {

    }

    public void SetPlayerColor(string a_color)
    {
        if (m_isActive)
        {
            Color color = Utils.ParseColor(a_color);
            Renderer renderer = m_player.GetComponent<Renderer>();
            renderer.material.color = color;
        }
    }

    public void Close()
    {
        m_pannel.SetActive(false);
        m_isActive = false;
        m_player.Freeze = false;
    }


}
