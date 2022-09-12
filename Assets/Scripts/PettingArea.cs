using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettingArea : MonoBehaviour, TaskArea
{
    public event Action TaskCompleted;

    [SerializeField] private List<GameObject> pettableAnimals;
    private int pettedAnimalCount = 0;
    private int totalNumOfAnimals;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in pettableAnimals)
        {
            obj.GetComponent<PettableObject>().PettingDone += PettingCompletedHandler;
        }

        totalNumOfAnimals = pettableAnimals.Count;
    }

    private void PettingCompletedHandler()
    {
        pettedAnimalCount++;
        Debug.Log("Animal was petted");

        if (pettedAnimalCount >= totalNumOfAnimals)
        {
            TaskCompleted?.Invoke();        
            Debug.Log("Task completed");

        }
    }

  
}
