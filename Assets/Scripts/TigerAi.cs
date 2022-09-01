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
    private TigerSound audioScript;
    private Animator anim;
    private float timeUntilPooping = 300f;
    private float timeSinceLastPoop = 0f;
    private bool canPoop = false;

    [SerializeField] private float hidingTimeInSeconds = 5f;
    [SerializeField] private float idlingTimeInSeconds = 8f;
    [SerializeField] private float roaringTimeInSeconds = 3f;
    [SerializeField] private float attackingTimeInSeconds = 3f;
    [SerializeField] private float poopingTimeInSeconds = 3f;
    [SerializeField] private Transform poopLocation;
    [SerializeField] private GameObject poopPrefab;


    
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
        movementScript.FootstepSfxShouldPlay += PlayFootstepsSoundEffect;
        movementScript.ReachedFood += OnReachedFood;
        anim = GetComponent<Animator>();
        audioScript = GetComponent<TigerSound>();
        Invoke(nameof(ActivateObjectAfterDelay), hidingTimeInSeconds);
        gameObject.SetActive(false);
    }

    private void OnReachedFood()
    {
        anim.SetTrigger(IDLE);
        movementScript.DisableMovement();
        currentState = TigerState.Idle;
    }

    private void Update()
    {
        timeSinceLastPoop += Time.deltaTime;
        if (timeSinceLastPoop >= timeUntilPooping)
        {
            canPoop = true;
            timeSinceLastPoop = 0f;
        }
    }

    private void PlayFootstepsSoundEffect()
    {
        audioScript.PlayFootstepsSound();
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
                audioScript.PlayRoarSound();
                StartCoroutine(EndStateAfterDelay(roaringTimeInSeconds));
                break;
            case TigerState.Attack:
                anim.SetTrigger(ATTACK);
                movementScript.DisableMovement();
                audioScript.PlayRoarSound();
                StartCoroutine(EndStateAfterDelay(attackingTimeInSeconds));
                break;
            case TigerState.Poop:
                anim.SetTrigger(IDLE);
                movementScript.DisableMovement();
                StartCoroutine(EndStateAfterDelay(poopingTimeInSeconds));
                if (canPoop)
                {
                    Instantiate(poopPrefab, poopLocation.position, Quaternion.identity);
                    timeSinceLastPoop = 0f;
                    canPoop = false;
                }
                break;
        }
    }

    IEnumerator EndStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RandomizeState();
    }

    public void PursueFood(Vector3 location)
    {
        anim.SetTrigger(WALK);
        movementScript.EnableMovement();
        movementScript.SetSpeedToWalking();
        movementScript.MoveTowardsFood(location);
        ZooLevelManager.instance.GameEnded();
    }
}
