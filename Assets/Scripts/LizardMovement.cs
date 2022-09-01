using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LizardMovement : MonoBehaviour
{
    Vector3[] patrolPoints = new Vector3[4];
    private int destPoint = 0;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        CreatePatrolPoints();
        GotoNextPoint();

    }

    void Update()
    {
        if (agent.enabled && !agent.pathPending && agent.remainingDistance < 3f)
        {
            GotoNextPoint();
        }
    }
    
    void GotoNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.destination = patrolPoints[destPoint];
        destPoint = Random.Range(0, patrolPoints.Length);
    }

    void CreatePatrolPoints()
    {
        patrolPoints[0] = transform.position + new Vector3(30f, 0, 0);
        patrolPoints[1] = transform.position + new Vector3(-30f, 0, 0);
        patrolPoints[2] = transform.position + new Vector3(0, 0, 30f);
        patrolPoints[3] = transform.position + new Vector3(0, 0, -30f);

    }
}
