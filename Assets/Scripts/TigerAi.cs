using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TigerAi : MonoBehaviour
{
    private enum TigerState
    {
        Idle,
        Walk,
        Run,
        Roar,
        Attack,
        Poop
    }

    private TigerState currentState = TigerState.Walk;
    private TigerMovement movementScript;
    private Animator anim;

    [SerializeField] private float hidingTimeInSeconds = 5f;
    [SerializeField] private float idlingTimeInSeconds = 8f;
    [SerializeField] private float roaringTimeInSeconds = 3f;
    [SerializeField] private float attackingTimeInSeconds = 3f;
    [SerializeField] private float poopingTimeInSeconds = 3f;


    
    private static readonly int WALK = Animator.StringToHash("Walk");
    private static readonly int RUN = Animator.StringToHash("Run");
    private static readonly int IDLE = Animator.StringToHash("Idle");
    private static readonly int ROAR = Animator.StringToHash("Roar");
    private static readonly int ATTACK = Animator.StringToHash("Attack");

    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<TigerMovement>();
        movementScript.PatrolStepCompleted += PatrolStepCompleted;
        anim = GetComponent<Animator>();
        Invoke(nameof(ActivateObjectAfterDelay), hidingTimeInSeconds);
        gameObject.SetActive(false);
    }

    private void PatrolStepCompleted()
    {
        RandomizeState();
    }

    private void RandomizeState()
    {
        int nextStateIndex = Random.Range(0, Enum.GetValues(typeof(TigerState)).Length);
        TigerState nextState = (TigerState)nextStateIndex;
        SetNewState(nextState);
    }


    private void ActivateObjectAfterDelay()
    {
        gameObject.SetActive(true);
        SetNewState(TigerState.Walk);
    }

    private void SetNewState(TigerState state)
    {
        currentState = state;
        
        switch (currentState)
        {
            case TigerState.Walk:
                anim.SetTrigger(WALK);
                movementScript.EnableMovement();
                movementScript.SetSpeedToWalking();
                movementScript.GotoNextPoint();
                break;
            case TigerState.Run:
                anim.SetTrigger(RUN);
                movementScript.EnableMovement();
                movementScript.SetSpeedToRunning();
                movementScript.GotoNextPoint();
                break;
            case TigerState.Idle:
                anim.SetTrigger(IDLE);
                movementScript.DisableMovement();
                StartCoroutine(EndStateAfterDelay(idlingTimeInSeconds));
                break;
            case TigerState.Roar:
                anim.SetTrigger(ROAR);
                movementScript.DisableMovement();
                StartCoroutine(EndStateAfterDelay(roaringTimeInSeconds));
                break;
            case TigerState.Attack:
                anim.SetTrigger(ATTACK);
                movementScript.DisableMovement();
                StartCoroutine(EndStateAfterDelay(attackingTimeInSeconds));
                break;
            case TigerState.Poop:
                anim.SetTrigger(IDLE);
                movementScript.DisableMovement();
                StartCoroutine(EndStateAfterDelay(poopingTimeInSeconds)); //ADD Poop prefab
                break;
        }
    }

    IEnumerator EndStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RandomizeState();
    }
}
