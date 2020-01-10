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
        if (this.name == "Player1")
        {
            pc.jump1 = false; 
        }
        else
        {
            pc.jump2 = false; 
        }
    }
}
