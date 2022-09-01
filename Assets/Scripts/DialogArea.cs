using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogArea : MonoBehaviour
{
    [SerializeField] private AudioClip dialogToPlay;
    private bool dialogHasPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!dialogHasPlayed)
            if (other.transform.CompareTag("Player"))
            {
                SoundManager.instance.PlaySfxGlobal(dialogToPlay);
                Destroy(gameObject, 5f);
            }
            
    }
}
