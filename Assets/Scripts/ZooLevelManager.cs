using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class ZooLevelManager : MonoBehaviour
{
    [SerializeField] private AudioClip introDialog;
    private float delayWhenGameWon = 10f;
    private string controlsHint = "Controls: WASD = move, SPACE = Jump, SHIFT = Run, MOUSE: Control Camera";
    
    void Start()
    {
        SoundManager.instance.PlaySfxGlobal(introDialog);
        UIManager.instance.DisplayTimedHint(controlsHint, 20f);
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
