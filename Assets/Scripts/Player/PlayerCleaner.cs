using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCleaner : MonoBehaviour
{
    [SerializeField] private BoxCollider cleaningRange;
    
    // Start is called before the first frame update
    void Start()
    {
        cleaningRange.enabled = false;

    }

    public void Clean()
    {
        cleaningRange.enabled = true;
        StartCoroutine(DisableCleaningAfterDelay());
    }

    IEnumerator DisableCleaningAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        cleaningRange.enabled = false;

    }
}
