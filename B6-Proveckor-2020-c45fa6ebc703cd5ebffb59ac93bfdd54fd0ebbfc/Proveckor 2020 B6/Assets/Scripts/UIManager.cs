using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pause;
    public GameObject setting;
    [HideInInspector] public bool pauseIsActive = false;

   
    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PauseMenu()
    {
        if (pauseIsActive)
        {
            pauseMenu.SetActive(false);
            pauseIsActive = false;
            pause.SetActive(true);
            setting.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            pauseIsActive = true;
            Time.timeScale = 0;
        }
    }
    public void TimeReset()
    {
        Time.timeScale = 1;
    }

   
}
