using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DialogueContainer : DialogueEntry
{
  //  public DialogueContainer m_parent = null;
    List<DialogueEntry> m_entries = null;
  //  bool m_hasParent = false;
    int m_dialogueStep = 0;


    public DialogueContainer(XmlNode a_node)
    {
        m_entries = new List<DialogueEntry>();
        Debug.Log(a_node.Name);

        foreach (XmlNode node in a_node.ChildNodes)
        {
            m_entries.Add(DialogueParser.GetEntriesInChild(this, node));
        }
    }

   /* public DialogueContainer(List<DialogueEntry> a_entries)
    {
        m_entries = a_entries;
    }*/

    /*public DialogueContainer(DialogueContainer a_parent, List<DialogueEntry> a_entries)
    {
  //      m_parent = a_parent;
          m_entries = a_entries;
   //     m_hasParent = true;
    }*/

    public override bool Read()
    {
        bool res = false;
        if (m_entries[m_dialogueStep].Read())
        {
            m_dialogueStep++;
            if(m_dialogueStep > m_entries.Count)
            {
                res = true;
            }
        }
        return res;
    }

    public void AddChild()
    {

    }

    /*  public void SetNewParent(DialogueContainer a_parent)
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
      }*/
}
