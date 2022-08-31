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
    private float turnSmoothVelocity;
    private Camera mainCam;

    private bool isGrounded = false;
    private bool isRunning = false;
    private float groundCheckDistance = 0.6f;
    [SerializeField] private LayerMask groundMask;
    private Vector3 velocity;
    private float gravity = -9.8f;
    
    
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCam = Camera.main;
    }
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = !isRunning; 
        
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
            
            //velocity.y = -100f * Time.deltaTime;
            
            if (Input.GetKeyUp(KeyCode.Space))
                Jump();
        }
        else
        {
            MoveMidair(moveDirection);
            velocity.y += gravity * Time.deltaTime;
        }
        
        ApplyGravity();

    }

    private void Walk(Vector3 walkingDirection)
    {
        controller.Move(walkingDirection.normalized * (walkSpeed * Time.deltaTime));

    }

    private void Run(Vector3 runningDirection)
    {
        controller.Move(runningDirection.normalized * (runSpeed * Time.deltaTime));

    }
    
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -gravity);

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
