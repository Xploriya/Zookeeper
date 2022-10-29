using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintArea : MonoBehaviour
{
    [SerializeField] private string hint;
    private bool hintHasBeenDisplayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!hintHasBeenDisplayed)
            if (other.transform.CompareTag("Player"))
            {
                UIManager.instance.DisplayTimedHint(hint, 10f);
                Destroy(gameObject, 5f);
            }
            
    }
}
