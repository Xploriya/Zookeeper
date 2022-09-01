using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooLevelManager : MonoBehaviour
{
    [SerializeField] private AudioClip introDialog;
    
    void Start()
    {
        SoundManager.instance.PlaySfxGlobal(introDialog);
    }

  
}
