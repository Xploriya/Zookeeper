using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleLevelManager : MonoBehaviour
{
    [SerializeField] private AudioClip introDialog;
    [SerializeField] private AudioClip jungleMusic;
    [SerializeField] private AudioClip jungleSfx;
    [SerializeField] private GameObject meatPrefab;

    private float delayWhenGameWon = 10f;
    private string controlsHint = "Controls: WASD = move, SPACE = Jump, SHIFT = Run, MOUSE: Control Camera";
    
    void Start()
    {
        SoundManager.instance.SetBackgroundMusic(jungleMusic);
        SoundManager.instance.SetLoopingSfx(jungleSfx);
        SoundManager.instance.PlaySfxGlobal(introDialog);
        UIManager.instance.DisplayTimedHint(controlsHint, 20f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMeatPlacer>().SwitchFood(meatPrefab);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void GameEnded()
    {
        PlayerPrefs.SetInt("Completed", 1);
        PlayerPrefs.Save();
        StartCoroutine(ShowWinMessageAfterDelay());
    }

    IEnumerator ShowWinMessageAfterDelay()
    {
        UIManager.instance.DisplayWinText();
        yield return new WaitForSeconds(delayWhenGameWon);
        UIManager.instance.HideWinText();
        GameManager.instance.LoadLevel(3);
    }


   
}
