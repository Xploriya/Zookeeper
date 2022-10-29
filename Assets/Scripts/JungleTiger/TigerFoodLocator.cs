using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerFoodLocator : MonoBehaviour
{
    private TigerAi tigerAi;
    private bool foodLocated = false;

    private void Start()
    {
        tigerAi = GetComponent<TigerAi>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food") && !foodLocated)
        {
            tigerAi.PursueFood(other.transform.position);
            foodLocated = true;
        }
    }
}
