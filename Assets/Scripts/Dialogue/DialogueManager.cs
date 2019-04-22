using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    private DialogueParser parser;

    [SerializeField]
    private List<DialogueWindow> m_dialogueWindows = null;
    
    private DialogueWindow m_activeWindow;
    private DialogueContainer m_activeDialogue;
    private bool m_hasDialogueActive = false;
    private bool m_isWindowOpen = false;
    private bool m_autoContinue = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        parser = new DialogueParser();
        if (m_dialogueWindows.Count > 0)
            m_activeWindow = m_dialogueWindows[0];
        else
            Debug.LogError("DialogueManager: Please link at least 1 DialogueWindow.");
    }

    private void Update()
    {
        if (m_autoContinue)
        {
            m_autoContinue = false;
            ContinueDialogue();
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            ContinueDialogue();
        }
    }

    public void parseXML(string _path)
    {
        m_activeDialogue = parser.parseXMLDialogue(_path);
        m_hasDialogueActive = true;
        ContinueDialogue();
    }

    private void ContinueDialogue()
    {
        if (m_hasDialogueActive)
        {
            if (m_activeDialogue.m_dialogueStep < m_activeDialogue.m_entries.Count)
            {
                //DialogueWindow
                if (m_activeDialogue.m_entries[m_activeDialogue.m_dialogueStep].GetType() == typeof(DialogueWindowMode))
                {
                    DialogueWindowMode mode = (DialogueWindowMode) m_activeDialogue.m_entries[m_activeDialogue.m_dialogueStep];
                    if(m_dialogueWindows.Count > mode.m_windowIndex)
                    {
                        //Close previous window and open the new one
                        CloseActiveWindow();
                        m_activeWindow = m_dialogueWindows[mode.m_windowIndex];
                        OpenActiveWindow();

                        //Set the parent of the subdialogue as the current dialogue
                        mode.m_subDialogue.SetNewParent(m_activeDialogue);
                        //Set SubDialogue as ActiveDialogue
                        m_activeDialogue = mode.m_subDialogue;
                        //Next step (choosing a window doesn't require input to continue)
                        m_autoContinue = true;
                        return;
                    }
                    else
                    {
                        Debug.LogError("DialogueManager: Index out of bound, window number "+ mode.m_windowIndex+" not linked to the Manager.");
                    }
                }
                //DialogueLine
                else if (m_activeDialogue.m_entries[m_activeDialogue.m_dialogueStep].GetType() == typeof(DialogueLine))
                {
                    if(!m_isWindowOpen) OpenActiveWindow();

                    DialogueLine line = (DialogueLine)m_activeDialogue.m_entries[m_activeDialogue.m_dialogueStep];
                    m_activeWindow.DisplayLine(line);
                }
                m_activeDialogue.m_dialogueStep++;
            }
            else
            {
                //Reactivate parent
                if (m_activeDialogue.HasParent())
                {
                    m_activeDialogue = m_activeDialogue.m_parent;
                    //Reopen the window of parent mode
                    CloseActiveWindow();
                    m_activeWindow = m_dialogueWindows[m_activeDialogue.m_dialogueWindow];
                    OpenActiveWindow();
                    m_activeDialogue.m_dialogueStep++;
                    m_autoContinue = true;
                }
                //End dialogue
                else {
                    m_activeWindow.ResetWindow();
                    m_hasDialogueActive = false;
                    CloseActiveWindow();
                }
            }
        }
    }

    private void OpenActiveWindow()
    {
        m_isWindowOpen = true;
        m_activeWindow.gameObject.SetActive(true);
    }

    private void CloseActiveWindow()
    {
        m_activeWindow.gameObject.SetActive(false);
        m_isWindowOpen = false;
    }
}
