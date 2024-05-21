using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class PatrolAI : MonoBehaviour, IMovable
{
    private NavMeshAgent _agent;
    public Transform[] waypoints;

    public bool isStopped = false;
    public bool isInDialogue = false;

    public AIDialogue dialogue;
    public AIDialogueManager dialogueManager;


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


        if (!isStopped && !isInDialogue && Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
        }

        if (!isInDialogue && !isStopped && DetectPlayer())
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
        dialogueManager.StartDialogue(dialogue, this);
    }

    public void EndDialogue()
    {
        Debug.Log("5234");
        isInDialogue = false;
        isStopped = false;

    }

}



public interface IMovable
{
    void CheckMovement(bool isStop);
}