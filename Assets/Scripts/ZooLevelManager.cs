using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooLevelManager : Singleton<ZooLevelManager>
{
    [SerializeField] private AudioClip introDialog;
    private float delayWhenGameWon = 15f;
    private string controlsHint = "Use W A S D to move, MOUSE to look around, SHIFT to run";
    
    void Start()
    {
        SoundManager.instance.PlaySfxGlobal(introDialog);
        UIManager.instance.DisplayTimedHint(controlsHint, 15f);

    }

    public void GameEnded()
    {
        StartCoroutine(ShowWinMessageAfterDelay());
    }

    IEnumerator ShowWinMessageAfterDelay()
    {
        yield return new WaitForSeconds(delayWhenGameWon);
        UIManager.instance.DisplayWinText();
    }

  
}
