using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerFoodLocator : MonoBehaviour
{
    private TigerAi tigerAi;

    private void Start()
    {
        tigerAi = GetComponent<TigerAi>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food")) 
            tigerAi.PursueFood(other.transform.position);
    }
}
