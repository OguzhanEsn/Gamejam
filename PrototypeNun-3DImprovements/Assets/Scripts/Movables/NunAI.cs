using UnityEngine.AI;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NunAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Transform[] waypoints;

    public bool isStopped = false;


    int waypointIndex;

    Vector3 target;



    private void Awake()
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

        if (!isStopped && Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
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
        Invoke(nameof(UpdateDestination), 3f);
        
    }

    public void CheckMovement(bool isStop)
    {
        this.isStopped = isStop;
    }





    public interface IMovable
    {
        void CheckMovement(bool isStop);
    }
}
