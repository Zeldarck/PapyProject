﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    private DialogueParser parser = new DialogueParser();

    [SerializeField]
    private List<DialogueWindow> m_dialogueWindows = null;
    
    private int m_windowIndex;
    private DialogueContainer m_dialogue;
    private bool m_hasDialogueActive = false;
    private bool m_isWindowOpen = false;
    bool m_nextIsClose = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            ContinueDialogue();
        }
    }

    public void ReadDialogue(string a_path)
    {
        m_dialogue = parser.ParseXMLDialogue(a_path);
        m_hasDialogueActive = true;
        m_nextIsClose = false;
        ContinueDialogue();
    }

    private void ContinueDialogue()
    {
        if (m_hasDialogueActive)
        {
            m_dialogueWindows[m_windowIndex].gameObject.SetActive(false);
            if (!m_nextIsClose && m_dialogue.Read())
            {
                m_nextIsClose = true;
            }
            else if (m_nextIsClose)
            {
                m_dialogueWindows[m_windowIndex].gameObject.SetActive(false);
                m_hasDialogueActive = false;
            }
        }
    }

    public void SetWindow(int a_index)
    {
        m_windowIndex = a_index;
    }

    public void DisplayLine(string a_character, string a_line)
    {
        m_dialogueWindows[m_windowIndex].gameObject.SetActive(true);
        m_dialogueWindows[m_windowIndex].DisplayLine(a_character, a_line);
    }

}
