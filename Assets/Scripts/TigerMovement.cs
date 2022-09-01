using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class TigerMovement : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] private float walkingSpeed = 2f;
    [SerializeField] private float runningSpeed = 4.5f;

    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool agentIsInitialized = false;
    
    public event Action PatrolStepCompleted; 
    
    


    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agentIsInitialized = true;

        GotoNextPoint();
    }


    public void GotoNextPoint() {
        if (patrolPoints.Length == 0 || !agentIsInitialized)
            return;

        agent.destination = patrolPoints[destPoint].position;
        destPoint = Random.Range(0, patrolPoints.Length);
    }


    void Update () {
        
        if (agent.enabled && !agent.pathPending && agent.remainingDistance < 3f)
            PatrolStepCompleted?.Invoke();
    }

    public void SetSpeedToWalking()
    {
        if(agentIsInitialized)
            agent.speed = walkingSpeed;
    }
    
    public void SetSpeedToRunning()
    {
        if(agentIsInitialized)
            agent.speed = runningSpeed;
    }

    public void DisableMovement()
    {
        if(agentIsInitialized)
            agent.enabled = false;
    }

    public void EnableMovement()
    {
        if(agentIsInitialized)
            agent.enabled = true;
    }
}
