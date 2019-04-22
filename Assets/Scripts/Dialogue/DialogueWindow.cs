using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    TextMeshProUGUI _characterZone;
    TextMeshProUGUI _textZone;

    private void Awake()
    {
        _characterZone = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _textZone = transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void DisplayLine(DialogueLine line)
    {
        _characterZone.text = line.m_character;
        _textZone.text = line.m_line;
    }

    public void ResetWindow()
    {
        _characterZone.text = "";
        _textZone.text = "";
    }
}
