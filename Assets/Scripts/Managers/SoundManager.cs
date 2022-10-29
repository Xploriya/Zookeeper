using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jungleSounds;

    /*void Start()
    {
        musicAudioSource.clip = backgroundMusic;
        musicAudioSource.loop = true;
        musicAudioSource.Play();

        sfxAudioSource.clip = jungleSounds;
        sfxAudioSource.loop = true;
        sfxAudioSource.Play();
    }*/

    public void PlaySfxSpatial(AudioClip clip, Vector3 location)
    {
        AudioSource.PlayClipAtPoint(clip, location);
    }

    public void PlaySfxGlobal(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip, 1f);
    }

    public void SetBackgroundMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    public void SetLoopingSfx(AudioClip sfxClip)
    {
        sfxAudioSource.clip = sfxClip;
        sfxAudioSource.loop = true;
        sfxAudioSource.Play();
    }

}
