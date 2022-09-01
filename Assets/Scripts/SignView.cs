using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignView : MonoBehaviour
{
    [SerializeField] private Transform lookPoint;

    [SerializeField] private Transform camPoint;

    private bool playerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                UIManager.instance.ToggleSignCamera(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            UIManager.instance.SetSignCameraPosition(camPoint, lookPoint);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            UIManager.instance.ToggleSignCamera(false);
        }
        
    }
}
