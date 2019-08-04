using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DialogueWindowMode : DialogueContainer
{
    int m_windowIndex;

    /*public DialogueWindowMode(int a_windowIndex)
    {
        m_windowIndex = a_windowIndex;
    }*/

    public DialogueWindowMode(XmlNode a_node) : base(a_node)
    {
        /*m_entries = new List<DialogueEntry>();
        foreach (XmlNode node in a_node.ChildNodes)
        {
            m_entries.Add(DialogueParser.GetEntriesInChild(this, node));
        }*/
    }


    public override bool Read()
    {
        //TO DO: set windows
        return base.Read();
    }

}
