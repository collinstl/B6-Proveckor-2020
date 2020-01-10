using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode[] movementKeys = { KeyCode.D, KeyCode.A, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.W, KeyCode.UpArrow };    
    public Vector2[] dir = { Vector2.right, Vector2.left, Vector2.right, Vector2.left };

    Rigidbody2D rb1;
    Rigidbody2D rb2;
    Transform player1;
    Transform player2;

    public float speed = 10;
    public float jumpForce = 100;
    public bool jump1 = false;
    public bool jump2 = false; 

    private void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        rb1 = player1.GetComponent<Rigidbody2D>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();
        rb2 = player2.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float vel = .8f * (1 / Time.deltaTime / 60); 

        for(int i = 0; i < 6; i++)
        {
            if (Input.GetKey(movementKeys[i]))
            {
                if(i < 2)
                {
                    rb1.velocity += dir[i] * speed * 60 * Time.deltaTime; 
                }
                else if(i > 1 && i < 4)
                {
                    rb2.velocity += dir[i] * speed * 60 * Time.deltaTime; 
                }               
            }
        }

        rb1.velocity = new Vector2(rb1.velocity.x * vel, rb1.velocity.y);
        rb2.velocity = new Vector2(rb2.velocity.x * vel, rb2.velocity.y);

        if (Input.GetKeyDown(movementKeys[4]) && !jump1)
        {
            rb1.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            jump1 = true;
        }

        if (Input.GetKeyDown(movementKeys[5]) && !jump2)
        {
            rb2.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            jump2 = true;
        }

    }
       
}
