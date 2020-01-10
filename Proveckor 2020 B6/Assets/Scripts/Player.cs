using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.name == "Player1") //Checks if player1 has touched ground - if so, player1 can jump again
        {
            pc.jump1 = false; 
        }
        else //Checks if player2 has touched ground - if so, player2 can jump again
        {
            pc.jump2 = false; 
        }
    }
}
