using UnityEngine.AI;
using UnityEngine;

public class PatrolAI : MonoBehaviour, IMovable
{
    private NavMeshAgent _agent;
    public Transform[] waypoints;

    public bool isStop = false;

    int waypointIndex;

    Vector3 target;


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
         if(isStop)
            {
                return;
            }
            

        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        _agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public void CheckMovement(bool isStop)
    {
        this.isStop = isStop;
    }

}


public interface IMovable
{
    void CheckMovement(bool isStop);
}