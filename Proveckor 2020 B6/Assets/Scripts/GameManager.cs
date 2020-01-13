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
    public float camDefaultSize = 7; // Default Size/Zoom of camera 
    #endregion Camera - Variables

    private void Start()
    {
        //Alexander Dolk
        #region Camera - Components
        cam = Camera.main;
        cameraRigidbody = cam.GetComponent<Rigidbody2D>();
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();        
        #endregion Camera - Components
    }

    private void Update()
    {
        //Alexander Dolk
        #region Camera
        float cDistance1 = Vector2.Distance(new Vector2(player1.position.x, 0), new Vector2(cam.transform.position.x, 0));
        float cDistance2 = Vector2.Distance(new Vector2(player2.position.x, 0), new Vector2(cam.transform.position.x, 0));
        if(cDistance1 + cDistance2 >= 11.3f) { cam.orthographicSize = (cDistance1 + cDistance2) * .44f; }
        else if(cam.orthographicSize <= 7){ cam.orthographicSize = camDefaultSize; }
        #endregion Camera 
    }
}
