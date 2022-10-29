using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPortal : MonoBehaviour
{
    [SerializeField] private int levelToLoadIndex;
    
    private string hintText = "Press E to Transport to the Zookeeper Experience";
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                UIManager.instance.HideControlsText();

                GameManager.instance.LoadLevel(levelToLoadIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            UIManager.instance.DisplayControlsText(hintText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            UIManager.instance.HideControlsText();
        }
        
    }
}
