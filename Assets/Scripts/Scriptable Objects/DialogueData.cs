using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Nidaa/DialogueData", order = 0)]
public class DialogueData : ScriptableObject
{
    int _dialogueIndex = 0;

    public int DialogueIndex
    {
        get
        {
            return _dialogueIndex;
        }
        set
        {
            _dialogueIndex = value;
        }
    }

    public int Length
    {
        get
        {
            return dialogueLines.Length;
        }
    }
    [SerializeField] DialogueLine[] dialogueLines;

    public string GetNextDialogueLine()
    {
        return dialogueLines[DialogueIndex++].DialogueText;
    }

}


[System.Serializable]
public class DialogueLine
{
    [SerializeField]
    [TextArea(1, 5)]
    string dialogeText;
    public string DialogueText
    {
        get
        {
            return dialogeText;
        }
    }
}



