using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private CinemachineVirtualCamera signCamera;
    private Transform camPoint;
    private Transform lookAtPoint;
    

    private void Start()
    {
        signCamera.enabled = false;
    }

    public void SetSignCameraPosition(Transform camPlace, Transform pointToLookAt)
    {
        camPoint = camPlace;
        lookAtPoint = pointToLookAt;

    }

    public void ToggleSignCamera(bool enableCam)
    {
        if (enableCam)
        {
            signCamera.enabled = true;
            signCamera.transform.position = camPoint.position;
            signCamera.LookAt = lookAtPoint.transform;
        }
        else
        {
            signCamera.enabled = false;
        }
    }
}
