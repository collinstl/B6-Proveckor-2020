using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    public GameObject pauseMenu;
    public GameObject setting;
    [HideInInspector] public bool pauseIsActive = false; 
    public CharacterSelection CharSel;
    #endregion Variables

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    #region Button Functions, St. Ledger
    public void PlayButton() //Loads Character Selection
    {
        SceneManager.LoadScene("SelectionScreen");
    }
    public void QuitButton() //Exit Game
    {
        Application.Quit();
    }
    public void MainMenuButton() //Returns to Scene 1, also used in character selection as a back button
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void PauseMenu() //Pauses game and opens pause menu
    {
        if (pauseIsActive)
        {
            pauseMenu.SetActive(false);
            pauseIsActive = false;
            setting.SetActive(false);
            TimeReset();
        }
        else
        {
            pauseMenu.SetActive(true);
            pauseIsActive = true;
            Time.timeScale = 0;
        }
    }
    public void TimeReset() //Makes sure the timescale is at 1 to avoid game being frozen by mistake
    {
        Time.timeScale = 1;
    }
    public void StartGame() //Loads game from character selection and loads in skins
    {
        SceneManager.LoadScene("MainScene");
        CharSel.LoadSkin();
    }

    #endregion Button Function, St. Ledger


    void UIScaling(RectTransform component, float sizePercentageX, float sizePercentageY, float posPercentageX, float posPercentageY)
    {
        GameObject parent = component.parent.gameObject;       
        RectTransform parentTransform = parent.GetComponent<RectTransform>();
        
        //Size
        component.sizeDelta = new Vector2(parentTransform.sizeDelta.x * sizePercentageX, parentTransform.sizeDelta.y * sizePercentageY);

        //Positioning

    }
}
