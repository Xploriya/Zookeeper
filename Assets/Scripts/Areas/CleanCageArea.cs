using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanCageArea : MonoBehaviour, TaskArea
{
    public event Action TaskCompleted;

    [SerializeField] private List<GameObject> poopToClean;
    private int cleanedItems = 0;

    private int totalItemsToClean;
    private bool isDone = false;
    
    void Start()
    {
        foreach (GameObject obj in poopToClean)
        {
            obj.GetComponent<Poop>().CleaningDone += CleaningCompletionHandler;
        }

        totalItemsToClean = poopToClean.Count;

    }

    private void CleaningCompletionHandler()
    {
        cleanedItems++;
        if (cleanedItems >= totalItemsToClean && !isDone)
        {
            isDone = true;
            TaskCompleted?.Invoke();
        }
    }

    

}
