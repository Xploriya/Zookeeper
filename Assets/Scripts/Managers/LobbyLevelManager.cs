using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyLevelManager : MonoBehaviour
{
    [SerializeField] private AudioClip lobbyMusic;
    [SerializeField] private AudioClip lobbySfx;
    void Start()
    {
        SoundManager.instance.SetBackgroundMusic(lobbyMusic);
        SoundManager.instance.SetLoopingSfx(lobbySfx);
    }
}
