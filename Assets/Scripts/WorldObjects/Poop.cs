using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public event Action CleaningDone;

    public void Clean()
    {
        CleaningDone?.Invoke();
        Destroy(gameObject, 0.1f);
    }
}
