using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DialogueWindowMode : DialogueContainer
{
    int m_windowIndex;
    bool m_alreadyRead = false;
    public DialogueWindowMode(XmlNode a_node) : base(a_node)
    {
        m_windowIndex = int.Parse(a_node.Attributes["id"].Value);
    }


    public override bool Read()
    {
        if (!m_alreadyRead)
        {
            DialogueManager.Instance.SetWindow(m_windowIndex);
        }
        return base.Read();
    }

}
