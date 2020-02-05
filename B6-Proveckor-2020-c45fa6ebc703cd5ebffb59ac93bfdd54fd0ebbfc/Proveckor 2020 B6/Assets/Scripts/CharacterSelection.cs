using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject[] P1Skins = new GameObject[2];
    [SerializeField] GameObject[] P2Skins = new GameObject[2];
    int current1;
    int current2;

    void Update()
    {
        SkinUpdate();
    }

    #region Character Skins Selection, St. Ledger
    public void PickCharacter1(int dir)
    {
        switch (dir)
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

    void SkinUpdate()
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

}
