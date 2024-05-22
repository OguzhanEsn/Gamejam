using UnityEngine.AI;
using UnityEngine;
using System.Collections;
using TMPro;
public class PatrolAI : MonoBehaviour, IMovable
{
    private NavMeshAgent _agent;
    public Transform[] waypoints;

    public bool isStopped = false;
    public bool isInDialogue = false;
    public bool shouldMove = true;

    public AIDialogue dialogue;
    public AIDialogueManager dialogueManager;
    public TextMeshProUGUI dialogueText;


    int waypointIndex;

    Vector3 target;

    public InventoryHandler inventoryHandler;
    public FieldOfView fieldOfView;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
         if(isStopped)
            {
                return;
            }


        if (!isStopped && shouldMove && !isInDialogue && Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
        }

        if (!isInDialogue && DetectPlayer())
        {
            
            if (inventoryHandler.HasKnife())
            {
                Debug.Log("has knife");
                StartDialogue();
            }
        }
    }


    void UpdateDestination()
    {
        isStopped = false;
        target = waypoints[waypointIndex].position;
        _agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
        isStopped = true;
        UpdateDestination();
    }

    public void CheckMovement(bool isStop)
    {
        this.isStopped = isStop;
    }


    public bool DetectPlayer()
    {

        fieldOfView.FindVisibleTargets();

 
        foreach (Transform target in fieldOfView.visibleTargets)
        {
            if (target.CompareTag("Player"))
            {
                return true; 
            }
        }

        return false; 
    }

    void StartDialogue()
    {
        isInDialogue = true;
        isStopped = true;
        dialogueManager.StartDialogue(dialogue, this, dialogueText);
    }

    public void EndDialogue()
    {
        Debug.Log("5234");
        isInDialogue = false;
        isStopped = false;
        dialogueText.text = "";
    }

}



public interface IMovable
{
    void CheckMovement(bool isStop);
}