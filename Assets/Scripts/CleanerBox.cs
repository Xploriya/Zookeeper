using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Poop"))
        {
            other.gameObject.GetComponent<Poop>().Clean();
        }

        if (other.CompareTag("Pet"))
        {
            other.gameObject.GetComponent<PettableObject>().Pet();
        }
    }
}
