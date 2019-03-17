using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine : DialogueEntry
{
    public string _character;
    public string _line;

    public DialogueLine(string character, string line)
    {
        _character = character;
        _line = line;
    }
}
