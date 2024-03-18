using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private TimerScript timerScript;

    void Start()
    {
        // TimerScript'e eriþmek için bul
        timerScript = FindObjectOfType<TimerScript>();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void SettingsButton() => SceneManager.LoadScene("Settings");

    public void MenuButton()
    {
        // Timer'ý sýfýrla ve MainMenu sahnesine geçiþ yap
        if (timerScript != null)
        {
            timerScript.ResetTimer();
        }
        SceneManager.LoadScene("MainMenu");
    }
}
