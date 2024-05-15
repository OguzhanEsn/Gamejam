using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;

    public Image charIcon;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI diaArea;
    public AudioSource source;

    private readonly Queue<DialogueLine> lines = new Queue<DialogueLine>();

    public bool isDialogueActive = false;

    public float typingSpeed = 0.001f;

    //public Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void StartDialouge(Dialogue dialogue)
    {
        isDialogueActive = true;

        //animator.Play("show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        charIcon.sprite = currentLine.character.icon;
        charName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));

    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        diaArea.text = "";
        source.clip = dialogueLine.clip;
        source.Play();
        
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            diaArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //animator.Play("hide");
    }
}
