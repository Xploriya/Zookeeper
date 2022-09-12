using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    private int tasksToFinish = 3;
    private int countOfCompletedTasks = 0;
    [SerializeField] public List<GameObject> taskAreas;
    [SerializeField] private GameObject doorToOpen;

    private void Start()
    {
        foreach (GameObject obj in taskAreas)
        {
            obj.GetComponent<TaskArea>().TaskCompleted += TaskCompletedHandler;
        }
    }

    public void TaskCompletedHandler()
    {
        countOfCompletedTasks++;
        UIManager.instance.DisplayTimedHint("Great, you completed this task successfully", 8f);

        if (countOfCompletedTasks >= tasksToFinish)
        {
            OpenJungleDoor();
        }
    }

    private void OpenJungleDoor()
    {
        doorToOpen.transform.Rotate(doorToOpen.transform.up, -90f);
        
    }
}
