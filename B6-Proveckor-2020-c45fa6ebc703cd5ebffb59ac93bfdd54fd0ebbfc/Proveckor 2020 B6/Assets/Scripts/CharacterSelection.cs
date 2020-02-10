using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject[] P1Skins = new GameObject[2]; //Stores the player skins. Array so can be expanded and add new skins anytime wanted
    [SerializeField] GameObject[] P2Skins = new GameObject[2];
    static public int current1; //Made static to be able to move character selection into game screen
    static public int current2;
    #endregion variables

    #region Character Skins Selection, St. Ledger

    void Update()
    {
        SkinUpdate();
    }

    public void PickCharacter1(int dir) //The buttons that rotate through the array
    {
        switch (dir) //Used a switch to lessen the amounts of voids necessary
        {
            case -1:
                if (current1 < (P1Skins.Length - 1))
                {
                    current1 = current1 + 1;
                }
                else if (current1 == (P1Skins.Length - 1))
                {
                    current1 = 0;
                }
                break;
            case 1:
                if (current1 <= P1Skins.Length - 1 && current1 != 0)
                {
                    current1 = current1 - 1;
                }
                else if (current1 == 0)
                {
                    current1 = P1Skins.Length - 1;
                }
                break;
        } 
    }

    public void PickCharacter2(int dir)
    {
        switch (dir)
        {
            case -1:
                if (current2 < (P2Skins.Length - 1))
                {
                    current2 = current2 + 1;
                }
                else if (current2 == (P2Skins.Length - 1))
                {
                    current2 = 0;
                }
                break;
            case 1:
                if (current2 <= P2Skins.Length - 1 && current2 != 0)
                {
                    current2 = current2 - 1;
                }
                else if (current2 == 0)
                {
                    current2 = P2Skins.Length - 1;
                }
                break;
        }

    }

    void SkinUpdate() //Shows the correct skin on screen
    {
        for(int i = 0; i < P1Skins.Length; i++)
        {
            if(i == current1)
            {
                P1Skins[current1].gameObject.SetActive(true);
            }
            else
            {
                P1Skins[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < P2Skins.Length; i++)
        {
            if (i == current2)
            {
                P2Skins[current2].gameObject.SetActive(true);
            }
            else
            {
                P2Skins[i].gameObject.SetActive(false);
            }
        }
    } 

    #endregion Character Skins Selection, St. Ledger

    public void LoadSkin() //Deactivates all skins except the chosen one when loading game. This is called in 'Start Game' in the UI manager
    {
        for(int i = 1; i < P1Skins.Length; i++)
        {
            P1Skins[i].gameObject.SetActive(false);
        }

        for (int i = 1; i < P2Skins.Length; i++)
        {
            P2Skins[i].gameObject.SetActive(false);
        }

        P1Skins[current1].gameObject.SetActive(true);
        P2Skins[current2].gameObject.SetActive(true);
    }
}