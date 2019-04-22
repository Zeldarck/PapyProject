using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContainer
{
    public DialogueContainer m_parent = null;
    public List<DialogueEntry> m_entries = null;
    bool m_hasParent = false;
    public int m_dialogueStep = 0;
    public int m_dialogueWindow = 0;

    public DialogueContainer()
    {
        m_entries = new List<DialogueEntry>();
    }

    public DialogueContainer(List<DialogueEntry> a_entries)
    {
        m_entries = a_entries;
    }

    public DialogueContainer(DialogueContainer a_parent, List<DialogueEntry> a_entries)
    {
        m_parent = a_parent;
        m_entries = a_entries;
        m_hasParent = true;
    }

    public void SetNewParent(DialogueContainer a_parent)
    {
        m_parent = a_parent;
        m_hasParent = true;
    }

    public void RemoveParent()
    {
        m_parent = null;
        m_hasParent = false;
    }

    public bool HasParent()
    {
        return m_hasParent;
    }
}
