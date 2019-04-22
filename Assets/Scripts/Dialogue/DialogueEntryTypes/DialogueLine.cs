using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine : DialogueEntry
{
    public string m_character;
    public string m_line;

    public DialogueLine(string a_character, string a_line)
    {
        m_character = a_character;
        m_line = a_line;
    }
}
