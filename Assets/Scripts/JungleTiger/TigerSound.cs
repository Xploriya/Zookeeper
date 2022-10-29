using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerSound : MonoBehaviour
{
    [SerializeField] private AudioClip roar;
    [SerializeField] private AudioClip footsteps;
    [SerializeField] private AudioClip finalDialog;

    public void PlayRoarSound()
    {
        SoundManager.instance.PlaySfxSpatial(roar, transform.position);
    }

    public void PlayFootstepsSound()
    {
        SoundManager.instance.PlaySfxSpatial(footsteps, transform.position);

    }

    public void PlayFinalDialog()
    {
        SoundManager.instance.PlaySfxGlobal(finalDialog);

    }
}
