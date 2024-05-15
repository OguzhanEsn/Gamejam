using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
    public AudioClip clip;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new();
}


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        if(!DialogueManager.instance.isDialogueActive)
        {
            TriggerDialogue();
            
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialouge(dialogue);
    }



}
