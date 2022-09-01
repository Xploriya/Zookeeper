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
    

    private void Start()
    {
        signCamera.enabled = false;
        winText.enabled = false;
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

    public void DisplayTimedHint(string hint, float delay)
    {
        controlsText.enabled = true;
        controlsText.text = hint;
        StartCoroutine(HideTextAfterDelay(delay));
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideControlsText();
    }
}
