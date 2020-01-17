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

    public GameObject balloonPrefab;
    public Animator[] catAnimators;
    public GameObject[] catPoses;
    [HideInInspector] public Animator balloonAnimator;

    public float countdownTimer = 5;
    public int points;
    [HideInInspector] public bool isPaused = true;

    bool firstEventRound = true;

    #region Camera - Variables, Alexander Dolk
    Camera cam;
    /*Rigidbody2D cameraRigidbody;
    public float camDefaultSize = 7; // Default Size/Zoom of camera */
    #endregion Camera - Variables, Alexander Dolk
    #region Random Events, Alexander Dolk   
    public float eventTimer = 10;
    public GameObject catPrefab;
    public float catForce = 1000;
    #endregion Random Events, Alexander Dolk    

    private void Awake()
    {
        //balloon = Instantiate(balloonPrefab, new Vector2(0, .2f), Quaternion.identity).GetComponent<Transform>();
        Time.timeScale = 0.000000000001f; //Sets the timescale to almost zero making it still possible to have a countdowntimer with the game "paused"
        StartCoroutine(StartGame());
    }
    private void Start()
    {
        StartCoroutine(RandomEvent());
        StartCoroutine(CatAnimation());
        //balloonAnimator = balloon.GetComponentInChildren<Animator>();
        for (int i = 0; i < catPoses.Length; i++) { if (i != 1) { catPoses[i].SetActive(false); } }
        #region Camera - Components, Alexander Dolk 
        cam = Camera.main;
        /*cameraRigidbody = cam.GetComponent<Rigidbody2D>();
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

    IEnumerator RandomEvent() //Starts a random event after the chosen time has gone to zero
    {
        yield return new WaitForSeconds(eventTimer);
        CatEvent();
        firstEventRound = false;
        yield return new WaitForSeconds(4);
        StartCoroutine(RandomEvent());
        StartCoroutine(CatAnimation());
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
        if (catDirection.x > 0) //Checks if cat is coming from left, if so - Flips sprite in the right direction
        {
            cat.GetComponentInChildren<Transform>().localScale = new Vector2(-cat.GetComponentInChildren<Transform>().localScale.x, cat.GetComponentInChildren<Transform>().localScale.y);
            catRigidbody.AddTorque(-100);
        }
        else { catRigidbody.AddTorque(100); }
        catRigidbody.AddForce(catDirection * catForce * Time.deltaTime); //Adds force to the cat
        Destroy(cat, 4);
    }

    IEnumerator CatAnimation()
    {
        #region KUK
        /*if (!firstEventRound)
        {
            catPoses[4].SetActive(true);
            catAnimators[4].SetBool("Walk", true);
            print("Before");
            yield return new WaitForSeconds(3.2f);
        }
        print("After");
        catAnimators[4].SetBool("Walk", false);
        catPoses[4].SetActive(false);
        catPoses[5].SetActive(true);
        catAnimators[5].SetBool("Jump", true);
        yield return new WaitForSeconds(.25f);
        catAnimators[5].SetBool("Jump", false);
        catPoses[5].SetActive(false);
        catPoses[6].SetActive(true);
        catAnimators[6].SetBool("FallAsleep", true);
        yield return new WaitForSeconds(2);
        catAnimators[6].SetBool("FallAsleep", false);
        catPoses[6].SetActive(false);
        catPoses[0].SetActive(true);
        catAnimators[0].SetBool("Sleep", true); //Sleep animation on loop until the event's closing in*/
        yield return new WaitForSeconds(eventTimer - 8.4f); //13.85 seconds before the event, sleeping animation stops and the cat starts waking up (waking up animation) 
        catAnimators[0].SetBool("Sleep", false);
        catPoses[0].SetActive(false);
        catPoses[1].SetActive(true);
        catAnimators[1].SetBool("Wake", true);
        yield return new WaitForSeconds(5.3f); //after waking up animation, cat runs through the jump animation
        catAnimators[1].SetBool("Wake", false);
        catPoses[1].SetActive(false);
        catPoses[2].SetActive(true);
        catAnimators[2].SetBool("Jump", true);
        yield return new WaitForSeconds(.6f); //after jumping, the cat runs through the walking animation and walks out of screen
        catAnimators[2].SetBool("Jump", false);
        catPoses[2].SetActive(false);
        catPoses[3].SetActive(true);
        catAnimators[3].SetBool("Walk", true);
        yield return new WaitForSeconds(2.5f); //Everything has been run through and event starts
        catAnimators[3].SetBool("Walk", false);
        catPoses[3].SetActive(false); 
        #endregion KUK
        /* print("Walking in"); 
         catPoses[4].SetActive(true);
         catAnimators[4].SetBool("Walk", true);
         yield return new WaitForSeconds(4);
         catAnimators[4].SetBool("Walk", false);
         catPoses[4].SetActive(false);
         catPoses[5].SetActive(true);
         catAnimators[5].SetBool("Jump", true);
         yield return new WaitForSeconds(.26f);
         catAnimators[5].SetBool("Jump", false);
         catPoses[5].SetActive(false); */
    }

    IEnumerator StartGame() //Starts the game after a few seconds so that players may prepare
    {
        print("Starting Soon!");
        yield return new WaitForSeconds(countdownTimer * Time.timeScale);
        Time.timeScale = 1;
        isPaused = false;
    }

    public IEnumerator GameOver() //Resets the game whenever the balloon has been destroyed
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Temporary gameover reset
        print("Points: " + points);
    }
}
