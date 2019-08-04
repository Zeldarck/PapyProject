using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DialogueLine : DialogueEntry
{
    public string m_character;
    public string m_line;

    public DialogueLine(XmlNode a_node)
    {
        Debug.Log("[Dialogue] Create " + a_node.InnerText);
    }

    /*public DialogueLine(string a_character, string a_line)
    {
        m_character = a_character;
        m_line = a_line;
    }*/

    public override bool Read()
    {
        //TODO : Display line
        return true;
    }
}
