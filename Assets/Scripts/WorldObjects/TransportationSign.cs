using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationSign : MonoBehaviour
{
    [SerializeField] private Transform lookPoint;
    [SerializeField] private Transform camPoint;
    [SerializeField] private int levelToLoadIndex;
    
    private string displayControlText = "Press E to view the sign";
    private string hideControlText = "Press E to return";


    private bool playerInRange = false;
    private bool signIsInFocus = false;


    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyUp(KeyCode.E))
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
            }
            
            if (Input.GetKeyUp(KeyCode.T))
            {
                GameManager.instance.LoadLevel(levelToLoadIndex);
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
