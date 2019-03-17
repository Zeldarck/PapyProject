using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public class DialogueParser
{

    public List<DialogueEntry> parseXMLDialogue(string path)
    {
        List<DialogueEntry> entries = new List<DialogueEntry>();

        path = "Assets/Resources/Dialogues/" + path;
        XmlDocument xmlDialogue = new XmlDocument();
        xmlDialogue.Load(path);

        foreach(XmlNode node in xmlDialogue.DocumentElement)
        {
            string type = node.Attributes[0].InnerText;

            switch (type)
            {
                case "window":
                    entries.Add(CreateDialogueWindowMode(node));
                    break;
                case "line":
                    entries.Add(CreateDialogueLine(node));
                    break;
                default: break;
            }
        }

        return entries;
    }

    private DialogueEntry CreateDialogueLine(XmlNode node)
    {
        //Add tests
        string character = node.ChildNodes[0].InnerText;
        string line = node.ChildNodes[1].InnerText;
        return new DialogueLine(character, line);
    }

    private DialogueEntry CreateDialogueWindowMode(XmlNode node)
    {
        int index = int.Parse(node.Attributes[1].InnerText);
        return new DialogueWindowMode(index);
    }
}
