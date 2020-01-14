using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Transform player1;
    [HideInInspector] public float player1Streak; //Streak for balloon hits in a row - player1 
    Transform player2;
    [HideInInspector] public float player2Streak; //Streak for balloon hits in a row - player2 
    Transform balloon; 
    public int points; 
    #region Camera - Variables, Alexander Dolk
    /*Camera cam;
    Rigidbody2D cameraRigidbody;
    public float camDefaultSize = 7; // Default Size/Zoom of camera */
    #endregion Camera - Variables, Alexander Dolk
    #region Random Events, Alexander Dolk   
    public float eventTimer = 10;
    public GameObject catPrefab;
    public float catForce = 1000;
    #endregion Random Events, Alexander Dolk
    public float countdownTimer = 5;
    [HideInInspector] public bool isPaused = true; 

    private void Awake()
    {
        Time.timeScale = 0.000000000001f;
        StartCoroutine(StartGame());
    }
    private void Start()
    {
        StartCoroutine(RandomEvent());
        balloon = GameObject.Find("Balloon").GetComponent<Transform>();
        #region Camera - Components, Alexander Dolk 
        /*cam = Camera.main;
        cameraRigidbody = cam.GetComponent<Rigidbody2D>();
        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();*/
        #endregion Camera - Components, Alexander Dolk
    }

    private void Update()
    {
        #region Camera, Alexander Dolk
        /*float cDistance1 = Vector2.Distance(new Vector2(player1.position.x, 0), new Vector2(cam.transform.position.x, 0));
        float cDistance2 = Vector2.Distance(new Vector2(player2.position.x, 0), new Vector2(cam.transform.position.x, 0));
        if (cDistance1 + cDistance2 >= 11.3f) { cam.orthographicSize = (cDistance1 + cDistance2) * .44f; }
        else if (cam.orthographicSize <= 7) { cam.orthographicSize = camDefaultSize; }*/
        #endregion Camera, Alexander Dolk 
    }

    IEnumerator RandomEvent()
    {
        yield return new WaitForSeconds(eventTimer);
        print("Random Event!");
        CatEvent();
        StartCoroutine(RandomEvent());
    }

    void CatEvent()
    {
        //Instantiate "cat" - Random position
        //add force - Across map
        int rand = Random.Range(1, 3); //Decides whether cat comes from left / right
        GameObject cat;
        Vector2 pos; pos.x = (rand == 1) ? 42 + Random.Range(0, 10) : -42 - Random.Range(0, 10); pos.y = -12; //Sets the spawn position of the newly spawned cat
        cat = Instantiate(catPrefab, pos, Quaternion.identity);
        Rigidbody2D catRigidbody = cat.GetComponent<Rigidbody2D>();
        Vector2 catDirection; catDirection.x = (rand == 1) ? -1 : 1; catDirection.y = 1; //Sets the correct direction for the cat to fly in 
        catRigidbody.AddForce(catDirection * catForce * Time.deltaTime); //Adds force to the cat
    }

    IEnumerator StartGame()
    {
        print("Starting Soon!");
        yield return new WaitForSeconds(countdownTimer * Time.timeScale);
        Time.timeScale = 1;
        isPaused = false; 
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Temporary gameover reset
        print("Points: " + points);
    }
}
