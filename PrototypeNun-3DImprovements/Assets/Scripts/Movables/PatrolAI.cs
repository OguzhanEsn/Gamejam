using UnityEngine.AI;
using UnityEngine;
using System.Collections;
using TMPro;
public class PatrolAI : MonoBehaviour, IMovable
{
    private NavMeshAgent _agent;
    public Transform[] waypoints;
    public Animator animator;

    public bool isStopped = false;
    public bool isInDialogue = false;

    public AIDialogue weaponDetected;
    public AIDialogue bloodyWeaponDetected;
    public AIDialogueManager dialogueManager;
    public TextMeshProUGUI dialogueText;

    public Transform player;

    int waypointIndex;

    Vector3 target;

    public InventoryHandler inventoryHandler;
    public FieldOfView fieldOfView;

    public AIDialogue targetKilledNearby;

    void OnEnable()
    {
        Patient.OnPatientKilled += HandlePatientKilled;
    }

    void OnDisable()
    {
        Patient.OnPatientKilled -= HandlePatientKilled;
    }

    void HandlePatientKilled(Patient patient)
    {
        if (fieldOfView.IsTargetVisible(player))
        {
            StartDialogue(targetKilledNearby);
        }
    }

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
            animator.SetBool("isMoving", false);
            return;
            }


        if (!isStopped && !isInDialogue && Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
        }

        if (!isInDialogue && DetectPlayer())
        {
            
            if (inventoryHandler.HasKnife())
            {
                Debug.Log("has knife");

                WeaponITSO scalpelSO = inventoryHandler.GetCurrentItem() as WeaponITSO;

                StartDialogue(weaponDetected);

            }
        }
    }


    void UpdateDestination()
    {
        isStopped = false;
        target = waypoints[waypointIndex].position;
        _agent.SetDestination(target);
        animator.SetBool("isMoving", true);
    }

    void IterateWaypointIndex()
    {
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
        isStopped = true;
        animator.SetBool("isMoving", false);
        Invoke(nameof(UpdateDestination), 3f);
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

    void StartDialogue(AIDialogue aIDialogue)
    {
        if (!isInDialogue && dialogueManager != null && !dialogueManager.IsDialogueTriggered(aIDialogue))
        {
            Debug.Log("Starting dialogue...");
            animator.SetBool("isMoving", false);
            isInDialogue = true;
            isStopped = true;

            dialogueManager.StartDialogue(aIDialogue, this, dialogueText);
        }
    }

    public void EndDialogue()
    {
        Debug.Log("5234");
        isInDialogue = false;
        isStopped = false;
        dialogueText.text = "";
        Debug.Log("bitti");
    }

}



public interface IMovable
{
    void CheckMovement(bool isStop);
}