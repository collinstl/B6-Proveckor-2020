using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController pc;
    GameManager gM;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        gM = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region Jump, Alexander Dolk
        if (this.name == "Player1") //Checks if player1 has touched ground - if so, player1 can jump again
        {
            pc.jump1 = false;
        }
        else //Checks if player2 has touched ground - if so, player2 can jump again
        {
            pc.jump2 = false;
        }
        #endregion Jump, Alexander Dolk
        if (collision.collider.tag == "Balloon")
        {
            if (this.name == "Player1")
            {
                gM.player1Streak += 1; // Adds a streak to player1
                gM.player2Streak = 0; // Removes streak from player2 
                pc.player1Speed -= (gM.player1Streak / 10) * 2; // Decreases player1 speed 
                pc.player2Speed = 4; // Restores player2 speed
            }
            else
            {
                gM.player2Streak += 1; // Adds a streak to player2
                gM.player1Streak = 0;// Removes streak from player1 
                pc.player2Speed -= (gM.player2Streak / 10) * 2;// Decreases player2 speed 
                pc.player1Speed = 4;// Restores player1 speed
            }

        }
    }
}
