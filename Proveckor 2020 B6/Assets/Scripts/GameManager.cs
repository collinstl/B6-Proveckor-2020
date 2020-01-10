using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Alexander Dolk
    #region Camera - Variables
    Transform player1;
    Transform player2;
    Camera cam;
    Rigidbody2D cameraRigidbody;
    float camDefaultSize; // Default Size/Zoom of camera 
    #endregion Camera - Variables

    private void Start()
    {
        //Alexander Dolk
        #region Camera - Components
        cam = Camera.main;
        cameraRigidbody = cam.GetComponent<Rigidbody2D>();
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();
        camDefaultSize = cam.orthographicSize;
        #endregion Camera - Components
    }

    private void Update()
    {
        //Alexander Dolk
        #region Camera
        float cDistance1 = Vector2.Distance(new Vector2(player1.position.x, 0), new Vector2(cam.transform.position.x, 0)); // Distance between player1 and Camera
        float cDistance2 = Vector2.Distance(new Vector2(player2.position.x, 0), new Vector2(cam.transform.position.x, 0));  // Distance between player2 and Camera
        if(cDistance1 > 11.3f && player1.position.x < 0) { cam.orthographicSize = cDistance1 * .44f;} // Zooms out camera if player1 goes out of the screen
        else if(cDistance2 > 11.3f && player2.position.x > 0) { cam.orthographicSize = cDistance2 * .44f;}// Zooms out camera if player2 goes out of the screen
        else { cam.orthographicSize = camDefaultSize; }
        #endregion Camera 
    }
}
