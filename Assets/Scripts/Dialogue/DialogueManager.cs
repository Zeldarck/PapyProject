using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public string path;
    private DialogueParser parser;

    [SerializeField]
    private List<DialogueWindow> _dialogueWindows = null;
    
    private DialogueWindow _activeWindow;
    private List<DialogueEntry> _activeDialogue;
    private int _dialogueStep;
    private bool _hasDialogueActive = false;
    private bool _isWindowOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        parser = new DialogueParser();
        if (_dialogueWindows.Count > 0)
            _activeWindow = _dialogueWindows[0];
        else
            Debug.LogError("DialogueManager: Please link at least 1 DialogueWindow.");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            ContinueDialogue();
        }
    }

    public void parseXML()
    {
        _activeDialogue = parser.parseXMLDialogue(path);
        _hasDialogueActive = true;
        _dialogueStep = 0;
        ContinueDialogue();
    }

    private void ContinueDialogue()
    {
        if (_hasDialogueActive)
        {
            if(_dialogueStep < _activeDialogue.Count)
            {
                //DialogueWindow
                if (_activeDialogue[_dialogueStep].GetType() == typeof(DialogueWindowMode))
                {
                    DialogueWindowMode mode = (DialogueWindowMode) _activeDialogue[_dialogueStep];
                    if(_dialogueWindows.Count > mode._windowIndex)
                    {
                        //Close previous window and open the new one
                        CloseActiveWindow();
                        _activeWindow = _dialogueWindows[mode._windowIndex];
                        OpenActiveWindow();
                        //Next step (choosing a window doesn't require input to continue)
                        _dialogueStep++;
                        ContinueDialogue();
                        return;
                    }
                    else
                    {
                        Debug.LogError("DialogueManager: Index out of bound, window number "+ mode._windowIndex+" not linked to the Manager.");
                    }
                }
                //DialogueLine
                else if (_activeDialogue[_dialogueStep].GetType() == typeof(DialogueLine))
                {
                    if(!_isWindowOpen) OpenActiveWindow();

                    DialogueLine line = (DialogueLine)_activeDialogue[_dialogueStep];
                    _activeWindow.DisplayLine(line);
                }
                _dialogueStep++;
            }
            else
            {
                _activeWindow.ResetWindow();
                _hasDialogueActive = false;
                CloseActiveWindow();
            }
        }
    }

    private void OpenActiveWindow()
    {
        _isWindowOpen = true;
        _activeWindow.gameObject.SetActive(true);
    }

    private void CloseActiveWindow()
    {
        _activeWindow.gameObject.SetActive(false);
        _isWindowOpen = false;
    }
}
