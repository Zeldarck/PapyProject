using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWindowMode : DialogueEntry
{
    public int m_windowIndex;
    public DialogueContainer m_subDialogue;

    public DialogueWindowMode(int a_windowIndex)
    {
        m_windowIndex = a_windowIndex;
        m_subDialogue = new DialogueContainer();
    }
}
