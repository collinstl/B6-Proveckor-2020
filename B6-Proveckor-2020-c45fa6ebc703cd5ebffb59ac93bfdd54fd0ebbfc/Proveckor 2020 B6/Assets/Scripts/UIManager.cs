using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject pauseMenu;
    GameObject pause;
    GameObject setting;
    [HideInInspector]public bool pauseIsActive = false;

    private void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pause = GameObject.Find("Pause");
        setting = GameObject.Find("Settings");
        pauseMenu.SetActive(false); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

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
        if(pauseIsActive)
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
