using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayButton() => SceneManager.LoadScene("Game");

    public void SettingsButton() => SceneManager.LoadScene("Settings");

    public void MenuButton() => SceneManager.LoadScene("MainMenu");
}
