using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class ZooLevelManager : MonoBehaviour
{
    
    [SerializeField] private AudioClip zooMusic;
    [SerializeField] private AudioClip zooSfx;
    [SerializeField] private GameObject applePrefab;
    void Start()
    {
        SoundManager.instance.SetBackgroundMusic(zooMusic);
        SoundManager.instance.SetLoopingSfx(zooSfx);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMeatPlacer>().SwitchFood(applePrefab);
    }
}
