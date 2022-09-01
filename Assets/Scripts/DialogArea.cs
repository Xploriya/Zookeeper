using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogArea : MonoBehaviour
{
    [SerializeField] private AudioClip dialogToPlay;
    [SerializeField] private string hint;
    private bool dialogHasPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!dialogHasPlayed)
            if (other.transform.CompareTag("Player"))
            {
                SoundManager.instance.PlaySfxGlobal(dialogToPlay);
                UIManager.instance.DisplayTimedHint(hint, 6f);
                Destroy(gameObject, 5f);
            }
            
    }
}
