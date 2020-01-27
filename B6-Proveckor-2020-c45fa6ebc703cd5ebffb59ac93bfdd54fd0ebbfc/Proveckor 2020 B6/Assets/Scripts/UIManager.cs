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

    Vector2 resolution;

    [System.Serializable]
    public class UIComponent
    {
        public RectTransform Component;
        [HideInInspector] public Vector2 sizePercentage;
        [HideInInspector] public Vector2 posPercentage; 
        
    }
    public UIComponent[] UIComponents;

    Scaler scaler; 
    private void Start()
    {
        scaler = GetComponent<Scaler>(); 
        resolution = new Vector2(Screen.width, Screen.height);
        for (int i = 0; i < UIComponents.Length; i++)
        {
            UIComponent component = UIComponents[i];
            Vector2 size = scaler.sizeList[i];
            Vector2 pos = scaler.posList[i];
            component.sizePercentage = size;
            component.posPercentage = pos; 
            UIScaling(component.Component, component.sizePercentage.x, component.sizePercentage.y, component.posPercentage.x, component.posPercentage.y);
        }
    }

    private void Update()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            for (int i = 0; i < UIComponents.Length; i++)
            {
                UIComponent component = UIComponents[i];
                UIScaling(component.Component, component.sizePercentage.x, component.sizePercentage.y, component.posPercentage.x, component.posPercentage.y);
            }
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


    void UIScaling(RectTransform component, float sizePercentageX, float sizePercentageY, float posPercentageX, float posPercentageY)
    {
        GameObject parent = component.parent.gameObject;       
        RectTransform parentTransform = parent.GetComponent<RectTransform>();
        
        //Size
        component.sizeDelta = new Vector2(parentTransform.sizeDelta.x * sizePercentageX, parentTransform.sizeDelta.y * sizePercentageY);

        //Positioning

    }
}
