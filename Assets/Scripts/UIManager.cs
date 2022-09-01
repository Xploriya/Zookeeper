using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private CinemachineVirtualCamera signCamera;
    [SerializeField] private TextMeshProUGUI controlsText;
    private Transform camPoint;
    private Transform lookAtPoint;
    
    

    private void Start()
    {
        signCamera.enabled = false;
        controlsText.enabled = false;
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

    public void DisplayControlsText(string text)
    {
        controlsText.enabled = true;
        controlsText.text = text;
    }
    
    public void HideControlsText()
    {
        controlsText.enabled = false;
    }
}
