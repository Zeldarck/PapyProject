using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public class DialogueParser
{

    public DialogueContainer ParseXMLDialogue(string a_path)
    {
        a_path = "Assets/Resources/Dialogues/" + a_path;
        XmlDocument xmlDialogue = new XmlDocument();
        xmlDialogue.Load(a_path);
        DialogueContainer dialogue = new DialogueContainer(xmlDialogue.ChildNodes[1]);
        

       /* foreach (XmlNode node in xmlDialogue.DocumentElement)
        {
            GetEntriesInChild(dialogue, node);
        }*/
        
        return dialogue;
    }

    //Todo put elsewhere
    public static DialogueEntry GetEntriesInChild(DialogueContainer a_dialogue, XmlNode a_node)
    {
        string type = a_node.Name;
        DialogueEntry res = null;
        switch (type)
        {
            case "window":
                res = new DialogueWindowMode(a_node);
              //  a_dialogue.m_entries.Add(windowMode);
                break;
            case "line":
                res = new DialogueLine(a_node);
                // a_dialogue.m_entries.Add(CreateDialogueLine(a_node));
                break;
            default:
                Debug.LogError("[Dialogue] Not a valid format " + type);
                break;
        }

        return res;

    }

   /* private DialogueEntry CreateDialogueLine(XmlNode a_node)
    {
        //Add tests
        string character = a_node.ChildNodes[0].InnerText;
        string line = a_node.ChildNodes[1].InnerText;
        return new DialogueLine(character, line);
    }*/

   /* private DialogueWindowMode CreateDialogueWindowMode(XmlNode a_node, DialogueContainer a_dialogue)
    {
        int index = int.Parse(a_node.Attributes[1].InnerText);
        DialogueWindowMode result = new DialogueWindowMode(index);
        foreach (XmlNode node in a_node.ChildNodes)
        {
          //  GetEntriesInChild(result.m_subDialogue, node);
        }
       // result.m_subDialogue.SetNewParent(a_dialogue);
        return result;
    }*/
}
