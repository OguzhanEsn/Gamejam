using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AIDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button nextButton;
    private readonly Queue<string> dialogueQueue = new Queue<string>();
    private HashSet<AIDialogue> triggeredDialogues;

    PatrolAI currentPatrolAI;

    private void Awake()
    {
        triggeredDialogues = new HashSet<AIDialogue>();
    }

    public void StartDialogue(AIDialogue dialogue, PatrolAI patrolAI)
    {
        if (triggeredDialogues.Contains(dialogue))
        {
            return;
        }

        triggeredDialogues.Add(dialogue);

        currentPatrolAI = patrolAI;

        Debug.Log("StartDialogue called");

        if (dialogue == null || dialogue.lines == null || dialogue.lines.Length == 0)
        {
            Debug.LogError("Dialogue or dialogue lines are null or empty");
            return;
        }

        dialogueQueue.Clear();
        foreach (string line in dialogue.lines)
        {
            dialogueQueue.Enqueue(line);
        }

        Debug.Log("Dialogue started with " + dialogueQueue.Count + " lines.");
      
        StartCoroutine(nameof(DisplayNextLine));
    }

    IEnumerator  DisplayNextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            
        }else
        {
            Debug.Log("Displaying next line. Remaining lines: " + dialogueQueue.Count);
            string line = dialogueQueue.Dequeue();

            if (dialogueText != null)
            {
                dialogueText.text = line;
            }
            else
            {
                Debug.LogError("DialogueText is null. Cannot display the line.");
            }

            yield return new WaitForSeconds(3f);
            StartCoroutine(nameof(DisplayNextLine));
        }

        
    }

    void EndDialogue()
    {
        dialogueText.text = "";
        currentPatrolAI.EndDialogue();
        currentPatrolAI = null;

    }
}
