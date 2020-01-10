using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    Transform balloon;
    Rigidbody2D rb; 
    public float balloonForce; 
     
    private void Start()
    {
        balloon = GameObject.Find("Balloon").GetComponent<Transform>();
        rb = balloon.GetComponent<Rigidbody2D>();
        int rand = Random.Range(1, 3);
        if (rand == 1) { rb.AddForce(new Vector2(1, 1) * 15000 * Time.deltaTime); }//Shoots balloon left/right at the start of the game
        if (rand == 2) { rb.AddForce(new Vector2(-1, 1) * 15000 * Time.deltaTime); }//Shoots balloon left/right at the start of the game  
       
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && balloon.position.x > 0) // Checks if player is touching balloon - if so, shoots balloon left/right depending on balloons position
        {
            rb.AddForce(new Vector2(-1, 1) * balloonForce * Time.deltaTime);
        }
        else if (collision.collider.tag == "Player" && balloon.position.x < 0)
        {
            rb.AddForce(new Vector2(1, 1) * balloonForce * Time.deltaTime);
        }
    }
}
