using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject setting;
    [HideInInspector] public bool pauseIsActive = false;

    //Scaling 
    public RectTransform[] uiComponents;
    public RectTransform[] parents;

    Vector2 resolution;
    private void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            for (int i = 0; i < uiComponents.Length; i++)
            {
                Scaling(uiComponents[i], parents[i]);
            }
            resolution = new Vector2(Screen.width, Screen.height);
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
        if (pauseIsActive)
        {
            pauseMenu.SetActive(false);
            pauseIsActive = false;
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

    void Scaling(RectTransform uiTransform, RectTransform parent)
    {
        //Scale
        float sizeX = uiTransform.sizeDelta.x * (1 + (uiTransform.sizeDelta.x / parent.sizeDelta.x));
        float sizeY = uiTransform.sizeDelta.y * (1 + (uiTransform.sizeDelta.y / parent.sizeDelta.y));
        uiTransform.sizeDelta = new Vector2(sizeX, sizeY);

        //Position
        float edgeOfParentX = uiTransform.anchoredPosition.x > 0 ? parent.anchoredPosition.x + (parent.sizeDelta.x / 2) : parent.anchoredPosition.x - (-parent.sizeDelta.x / 2);
        float edgeOfParentY = uiTransform.anchoredPosition.y > 0 ? parent.anchoredPosition.y + (parent.sizeDelta.y / 2) : parent.anchoredPosition.y - (-parent.sizeDelta.y / 2);
        float offsetX = uiTransform.anchoredPosition.x > 0 ? edgeOfParentX - (uiTransform.anchoredPosition.x + uiTransform.anchoredPosition.x / 2) : edgeOfParentX + (uiTransform.anchoredPosition.x - uiTransform.anchoredPosition.x / 2); //Distance between edge of child ui and parent ui (X)
        float offsetY = uiTransform.anchoredPosition.y > 0 ? edgeOfParentY - (uiTransform.anchoredPosition.y + uiTransform.anchoredPosition.y / 2) : edgeOfParentY + (uiTransform.anchoredPosition.y - uiTransform.anchoredPosition.y / 2); //Distance between edge of child ui and parent ui (Y)
        float posPercentageX = offsetX / parent.sizeDelta.x;
        float posPercentageY = offsetY / parent.sizeDelta.y;
        float posX = uiTransform.anchoredPosition.x > 0 ? (parent.anchoredPosition.x + (parent.sizeDelta.x / 2)) - (uiTransform.anchoredPosition.x + (uiTransform.sizeDelta.x / 2) + (offsetX * posPercentageX)) : (parent.anchoredPosition.x - (parent.sizeDelta.x / 2)) + (uiTransform.anchoredPosition.x - (uiTransform.sizeDelta.x / 2) - (offsetX * posPercentageX));
        float posY = uiTransform.anchoredPosition.y > 0 ? (parent.anchoredPosition.y + (parent.sizeDelta.y / 2)) - (uiTransform.anchoredPosition.y + (uiTransform.sizeDelta.y / 2) + (offsetY * posPercentageY)) : (parent.anchoredPosition.y - (parent.sizeDelta.y / 2)) + (uiTransform.anchoredPosition.y - (uiTransform.sizeDelta.y / 2) - (offsetY * posPercentageY));
        uiTransform.position = new Vector2(posX, posY);
    }
}
