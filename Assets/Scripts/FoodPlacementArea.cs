using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacementArea : MonoBehaviour, TaskArea
{
    public event Action TaskCompleted;
    private bool foodLocated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food") && !foodLocated)
        {
            foodLocated = true;
            TaskCompleted?.Invoke();
            Destroy(gameObject, 3f);
        }
    }

}
