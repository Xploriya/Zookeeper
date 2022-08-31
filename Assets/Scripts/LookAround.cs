using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float mouseSensitivity = 100f;


    private bool cameraMovementEnabled = true;

    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (cameraMovementEnabled)
        {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

            player.transform.Rotate(Vector3.up, mouseX);

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        }

    }

    public void DisableCameraMovement()
    {
        cameraMovementEnabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void EnableCameraMovement()
    {
        cameraMovementEnabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
