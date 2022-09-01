using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float midairSpeed = 3f;
    [SerializeField] private float rotationSmoothingFactor = 0.1f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private Animator anim;
    private float turnSmoothVelocity;
    private Camera mainCam;

    private bool isGrounded = false;
    private bool isRunning = false;
    private bool isJumping = false;
    
    private float groundCheckDistance = 0.6f;
    [SerializeField] private LayerMask groundMask;
    private Vector3 velocity;
    private float gravity = -9.8f;
    private float groundCheckDelay = 0.5f;
    private float timeSinceJump = 0f;
    private bool canCheckForGround = true;
    private Vector3 direction = Vector3.zero;

    
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCam = Camera.main;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void ToggleRunning()
    {
        isRunning = !isRunning;
    }
    
    void Update()
    {
        
        if(canCheckForGround)
            isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        else
        {
            timeSinceJump += Time.deltaTime;
            if (timeSinceJump >= groundCheckDelay)
            {
                timeSinceJump = 0;
                canCheckForGround = true;
            }
        }
        
        
        MovePlayer(direction);
    }

   

    private void MovePlayer(Vector3 direction)
    {
        float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCam.transform.eulerAngles.y;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref turnSmoothVelocity, rotationSmoothingFactor);
        transform.rotation = Quaternion.Euler(0, smoothAngle,0);

        Vector3 moveDirection = Quaternion.Euler(0, rotationAngle, 0) * Vector3.forward;
        
        if (isGrounded)
        {
            if (direction.magnitude >= 0.1f)
            {
                if(isRunning)
                    Run(moveDirection);
                else
                    Walk(moveDirection);
                
            }
            else
            {
                Idle();
            }
            
            //velocity.y = -100f * Time.deltaTime;
            if (isJumping)
            {
                isJumping = false;
                anim.SetTrigger("Grounded");
            }
            
        }
        else
        {
            if (direction.magnitude > 0.1f)
            {
                MoveMidair(moveDirection);
            }
            velocity.y += gravity * Time.deltaTime;

        }
        
        ApplyGravity();

    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.15f, Time.deltaTime);
    }

    private void Walk(Vector3 walkingDirection)
    {
        controller.Move(walkingDirection.normalized * (walkSpeed * Time.deltaTime));
        anim.SetFloat("Speed", walkSpeed, 0.15f, Time.deltaTime);

    }

    private void Run(Vector3 runningDirection)
    {
        controller.Move(runningDirection.normalized * (runSpeed * Time.deltaTime));
        anim.SetFloat("Speed", runSpeed, 0.15f, Time.deltaTime);

    }
    
    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        anim.SetTrigger("Jump");
        isJumping = true;
        canCheckForGround = false;
        isGrounded = false;
    }

    private void MoveMidair(Vector3 midairDirection)
    {
        controller.Move(midairDirection.normalized * (midairSpeed * Time.deltaTime));

    }

    private void ApplyGravity()
    {
        controller.Move(velocity * Time.deltaTime);

    }
}
