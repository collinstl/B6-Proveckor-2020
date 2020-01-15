using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    Transform balloon;
    Transform player1;
    Transform player2;
    Transform wallLeft;
    Transform wallRight;
    Rigidbody2D rb;
    GameManager gM;

    public float balloonForce;
    public float wallBounce;

    float angle;
    Vector2 dif;
    bool isIncreasing = false;
    bool calculateAngle = false; 

    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();
        balloon = GameObject.Find("Balloon").GetComponent<Transform>();
        wallLeft = GameObject.Find("Barrier_Left").GetComponent<Transform>();
        wallRight = GameObject.Find("Barrier_Right").GetComponent<Transform>();
        rb = balloon.GetComponent<Rigidbody2D>();
        int rand = Random.Range(1, 3);
        if (rand == 1) { rb.AddForce(new Vector2(1, 1) * 15000 * Time.deltaTime); }//Shoots balloon left/right at the start of the game
        if (rand == 2) { rb.AddForce(new Vector2(-1, 1) * 15000 * Time.deltaTime); }//Shoots balloon left/right at the start of the game
        StartCoroutine(VelocityChange());
    }

    private void Update()
    {
        if (transform.position.x < 0)
        {
            dif = new Vector2(transform.position.x - (wallLeft.position.x - 5), wallLeft.position.y - transform.position.y);
            Debug.DrawLine(new Vector2(wallLeft.position.x - 5, wallLeft.position.y), new Vector2(transform.position.x, wallLeft.position.y), Color.blue); //Horizontal Line
            Debug.DrawLine(new Vector2(wallLeft.position.x - 5, wallLeft.position.y), transform.position, Color.blue); //Hypotenuse
            if(Mathf.Abs(transform.position.x - wallLeft.position.x) < 5 && !calculateAngle)
            {
                angle = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
                calculateAngle = true; 
            }
            
           // print("Angle: " + angle);
        }
        else
        {
            dif = new Vector2((wallRight.position.x + 5) - transform.position.x, Mathf.Abs(wallRight.position.y - transform.position.y));
            Debug.DrawLine(new Vector2(wallRight.position.x + 5, wallRight.position.y), new Vector2(transform.position.x, wallRight.position.y), Color.blue); //Horizontal Line
            Debug.DrawLine(new Vector2(wallRight.position.x + 5, wallRight.position.y), transform.position, Color.blue); //Hypotenuse
            if (Mathf.Abs(transform.position.x - wallRight.position.x) < 5 && !calculateAngle)
            {
                angle = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
                calculateAngle = true;
            }
            //print("Angle: " + angle);
        }
        print("isIncreasing: " + isIncreasing); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Player Collision
        if (collision.collider.name == "Player1" && player1.position.x > player2.position.x) // Checks if player is touching balloon - if so, shoots balloon left/right depending on balloons position
        {
            rb.AddForce(new Vector2(-1, 1) * balloonForce * Time.deltaTime);
            gM.points += 1;
        }
        else if (collision.collider.name == "Player1") { rb.AddForce(new Vector2(1, 1) * balloonForce * Time.deltaTime); gM.points += 1; }

        if (collision.collider.name == "Player2" && player1.position.x > player2.position.x) // Checks if player is touching balloon - if so, shoots balloon left/right depending on balloons position
        {
            rb.AddForce(new Vector2(1, 1) * balloonForce * Time.deltaTime);
            gM.points += 1;
        }
        else if (collision.collider.name == "Player2") { rb.AddForce(new Vector2(-1, 1) * balloonForce * Time.deltaTime); gM.points += 1; }

        //Environment Collision
        if (collision.collider.tag == "Wall")
        {
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (isIncreasing && transform.position.x > 0)
            { rb.AddForce(new Vector2(-dir.x, dir.y) * wallBounce * Time.deltaTime); calculateAngle = false; }
            if (isIncreasing && transform.position.x < 0)
            { rb.AddForce(new Vector2(dir.x, dir.y) * wallBounce * Time.deltaTime); calculateAngle = false; }
            if (!isIncreasing && transform.position.x > 0)
            { rb.AddForce(new Vector2(-dir.x, -dir.y) * wallBounce * Time.deltaTime); calculateAngle = false; }
            if (!isIncreasing && transform.position.x < 0)
            { rb.AddForce(new Vector2(dir.x, -dir.y) * wallBounce * Time.deltaTime); calculateAngle = false; }
        }

        //Gameover
        if (collision.collider.tag == "Ground") { gM.GameOver(); gM.balloonAnimator.SetBool("Gameover", true); } //Declares Gameover if balloon touches ground
        if (collision.collider.tag == "Event") { gM.GameOver(); gM.balloonAnimator.SetBool("Gameover", true); } //Declares Gameover if balloon touches cat / other event
    }

    IEnumerator VelocityChange()
    {
        float originalVelocity = rb.velocity.y;
        yield return new WaitForSeconds(.1f);
        float newVelocity = rb.velocity.y; 
        if(newVelocity > originalVelocity) { isIncreasing = true; }
        else { isIncreasing = false; }
        StartCoroutine(VelocityChange());
    }
}
