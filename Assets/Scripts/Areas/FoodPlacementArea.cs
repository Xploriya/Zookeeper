using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacementArea : MonoBehaviour, TaskArea
{
    public event Action TaskCompleted;
    [SerializeField] private int numOfFoodsRequired = 3;
    private bool isDone = false;

    private int foodsPlacedSoFar = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food") && foodsPlacedSoFar < numOfFoodsRequired )
        {
            foodsPlacedSoFar++;
            if (foodsPlacedSoFar >= numOfFoodsRequired&& !isDone)
            {
                isDone = true;
                TaskCompleted?.Invoke();
                Destroy(gameObject, 3f);
            }
            
        }
    }

}
