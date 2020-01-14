using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    Transform balloon;
    Transform player1;
    Transform player2; 
    Rigidbody2D rb;
    GameManager gM; 

    public float balloonForce; 
     
    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>(); 
        balloon = GameObject.Find("Balloon").GetComponent<Transform>();
        rb = balloon.GetComponent<Rigidbody2D>();
        int rand = Random.Range(1, 3);
        if (rand == 1) { rb.AddForce(new Vector2(1, 1) * 15000 * Time.deltaTime); }//Shoots balloon left/right at the start of the game
        if (rand == 2) { rb.AddForce(new Vector2(-1, 1) * 15000 * Time.deltaTime); }//Shoots balloon left/right at the start of the game
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player1" && player1.position.x > player2.position.x) // Checks if player is touching balloon - if so, shoots balloon left/right depending on balloons position
        {
            rb.AddForce(new Vector2(-1, 1) * balloonForce * Time.deltaTime);
            gM.points += 1;
        }
        else if(collision.collider.name == "Player1") { rb.AddForce(new Vector2(1, 1) * balloonForce * Time.deltaTime); }
        
        if (collision.collider.name == "Player2" && player1.position.x > player2.position.x) // Checks if player is touching balloon - if so, shoots balloon left/right depending on balloons position
        {
            rb.AddForce(new Vector2(1, 1) * balloonForce * Time.deltaTime);
            gM.points += 1; 
        }
        else if(collision.collider.name == "Player2") { rb.AddForce(new Vector2(-1, 1) * balloonForce * Time.deltaTime); }

        if(collision.collider.tag == "Ground") { gM.GameOver(); } //Declares Gameover if balloon touches ground
        if(collision.collider.tag == "Event") { gM.GameOver(); } //Declares Gameover if balloon touches cat / other event
    }
}
