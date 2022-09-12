using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningSign : MonoBehaviour
{
    [SerializeField] private Transform lookPoint;

    [SerializeField] private Transform camPoint;
    [SerializeField] private Transform doorToOpen;

    private string displayControlText = "Press X to view the sign";
    private string hideControlText = "Press X to return";


    private bool playerInRange = false;
    private bool signIsInFocus = false;
    private bool doorIsOpen = false;


    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (!signIsInFocus)
                {
                    signIsInFocus = true;
                    UIManager.instance.ToggleSignCamera(true);
                    UIManager.instance.DisplayControlsText(hideControlText);

                }
                else
                {
                    signIsInFocus = false;
                    UIManager.instance.ToggleSignCamera(false);
                    UIManager.instance.DisplayControlsText(displayControlText);

                }

                if (!doorIsOpen)
                {
                    doorIsOpen = true;
                    doorToOpen.Rotate(doorToOpen.up, -60f);
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            UIManager.instance.SetSignCameraPosition(camPoint, lookPoint);
            UIManager.instance.DisplayControlsText(displayControlText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            UIManager.instance.ToggleSignCamera(false);
            UIManager.instance.HideControlsText();
        }
        
    }
}
