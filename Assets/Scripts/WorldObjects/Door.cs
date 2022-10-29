using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool doorIsOpen = false;
    private float closureDelay = 7f;
    private Quaternion originalRotation;
    private bool playerInRange = false;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!doorIsOpen)
        {
            if (other.transform.CompareTag("Player"))
            {
                playerInRange = true;
                UIManager.instance.DisplayTimedHint("Press E to open the door", 10f);
                
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playerInRange = false;
               
        }   
    }

    private void Update()
    {               

        if (Input.GetKeyUp(KeyCode.E) && !doorIsOpen && playerInRange)
        {
            doorIsOpen = true;
            StartCoroutine(CloseDoorAfterDelay());
            transform.Rotate(transform.up, -60f);
            StartCoroutine(CloseDoorAfterDelay());

        }
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closureDelay);
        doorIsOpen = false;
        transform.rotation = originalRotation;
    }
}