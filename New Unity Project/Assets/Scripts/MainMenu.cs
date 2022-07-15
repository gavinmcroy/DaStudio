using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void PlayGame()
    {
        Fade.instance.StartTransition("Level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLeve2()
    {
        Fade.instance.StartTransition("Level 2");
    }

    public void LoadLevel3()
    {
        Fade.instance.StartTransition("Level 3");
    }
}
