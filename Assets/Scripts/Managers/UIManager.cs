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
    [SerializeField] private TextMeshProUGUI winText;
    private Transform camPoint;
    private Transform lookAtPoint;

    private bool dialogIsOpen = false;
    private float timeToHideMessage = 8f;
    private float timeSinceMessageAppeared = 0f;


    private void Start()
    {
        signCamera.enabled = false;
        winText.enabled = false;
    }

    private void Update()
    {
        if (dialogIsOpen)
        {
            timeSinceMessageAppeared += Time.deltaTime;
            if (timeSinceMessageAppeared >= timeToHideMessage)
            {
                dialogIsOpen = false;
                timeSinceMessageAppeared = 0f;
                HideControlsText();
            }
        }
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

    public void DisplayWinText()
    {
        winText.enabled = true;
    }

    public void HideWinText()
    {
        winText.enabled = false;
    }

    public void DisplayTimedHint(string hint, float delay)
    {
        controlsText.enabled = true;
        controlsText.text = hint;

        dialogIsOpen = true;
        timeSinceMessageAppeared = 0f;
        timeToHideMessage = delay;
    }


    public void RelinkSignCamera()
    {
        signCamera = GameObject.FindGameObjectWithTag("SignCamera").GetComponent<CinemachineVirtualCamera>();
    }
}