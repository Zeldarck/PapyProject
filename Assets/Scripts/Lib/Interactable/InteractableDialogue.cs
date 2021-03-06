﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDialogue : Interactable
{
    [SerializeField]
    [Tooltip("The name of the xml dialogue file in the Resources folder.")]
    private string m_dialoguePath = "";

    [SerializeField]
    [Tooltip("True if the dialogue can be replayed. Else can only be played once. - NOT IMPLEMENTED")]
    private bool m_multiplePass = true;

    protected override void Start()
    {
        base.Start();
    }

    public override bool Interact(PlayerController a_player)
    {
        bool res = base.Interact(a_player);

        DialogueManager.Instance.ReadDialogue(m_dialoguePath);
        SpokeTo();
        return res;
    }

    private void SpokeTo()
    {
        m_identity.ObjectIdentity.SpokeTo(true);
    }
}
