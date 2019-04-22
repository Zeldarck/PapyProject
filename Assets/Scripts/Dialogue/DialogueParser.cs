using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public class DialogueParser
{

    public DialogueContainer parseXMLDialogue(string a_path)
    {
        a_path = "Assets/Resources/Dialogues/" + a_path;
        XmlDocument xmlDialogue = new XmlDocument();
        xmlDialogue.Load(a_path);
        DialogueContainer dialogue = new DialogueContainer();

        foreach(XmlNode node in xmlDialogue.DocumentElement)
        {
            GetEntriesInChild(dialogue, node);
        }
        
        return dialogue;
    }

    private void GetEntriesInChild(DialogueContainer a_dialogue, XmlNode a_node)
    {
        string type = a_node.Attributes[0].InnerText;

        switch (type)
        {
            case "window":
                DialogueWindowMode windowMode = CreateDialogueWindowMode(a_node, a_dialogue);
                a_dialogue.m_entries.Add(windowMode);
                break;
            case "line":
                a_dialogue.m_entries.Add(CreateDialogueLine(a_node));
                break;
            default: break;
        }

    }

    private DialogueEntry CreateDialogueLine(XmlNode a_node)
    {
        //Add tests
        string character = a_node.ChildNodes[0].InnerText;
        string line = a_node.ChildNodes[1].InnerText;
        return new DialogueLine(character, line);
    }

    private DialogueWindowMode CreateDialogueWindowMode(XmlNode a_node, DialogueContainer a_dialogue)
    {
        int index = int.Parse(a_node.Attributes[1].InnerText);
        DialogueWindowMode result = new DialogueWindowMode(index);
        foreach (XmlNode node in a_node.ChildNodes)
        {
            GetEntriesInChild(result.m_subDialogue, node);
        }
        result.m_subDialogue.SetNewParent(a_dialogue);
        return result;
    }
}
