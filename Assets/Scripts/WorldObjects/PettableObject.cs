using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettableObject : MonoBehaviour
{
    public event Action PettingDone;

    public void Pet()
    {
        PettingDone?.Invoke();
    }
}
