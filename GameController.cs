//Handles the logic behind spawning hazards
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject balls;
    public GameObject spinner;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public Transform canvas;
    public bool gameOver;
    public bool restart;
    public int hazardCount;
    public float startWait;    
    public float spawnWait;    
    public float waveWait;
    public Text restartText;
    public Text gameOverText;
    public Spinner spin;

    private Vector3 spawnPosition;
    private Vector3 spinnerPosition;
    private float startSpinnerWait;
    private float respawnSpinnerWait;
    private int nRails = 0;

    // Use this for initialization
    void Start()
    {
        gameOver = restart = false;
        restartText.text = "";
        gameOverText.text = "";

        //randomize Spinner spawn time within game session
        startSpinnerWait = Random.Range(10, 20);
        spinnerPosition = new Vector3(0, 0, 0);


        //sets randomized spawn points for balls
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnSpinner());
    }

    void Update()
    {
        //toggle pause menu with escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
                
        //when game over, check for R input and restart current (or a specified) scene
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
            }
        }

    }

    IEnumerator SpawnWaves() //Example of a Coroutine to suspend code exectuion so it only runs at intervals of the game
    {
        yield return new WaitForSeconds(startWait); //delay first wave by a few seconds
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //randomize which cannon spot the balls launch from
                int spawnValue = (int) (Random.Range (0, 4));

                //use case-switch with spawnValue to decide spawn position
                switch (spawnValue)
                {
                    case 0:
                        //shoot from NE cannon
                        spawnPosition = new Vector3 (12, 6, 12);                                            
                        break;

                    case 1:
                        //shoot from NW cannon
                        spawnPosition = new Vector3 (-12, 6, 12);
                        break;

                    case 2:
                        //shoot from SW cannon
                        spawnPosition = new Vector3 (-12, 6, -12);
                        break;

                    default:
                        //shoot from SE cannon
                        spawnPosition = new Vector3 (12, 6, -12);
                        break;
                }
                Quaternion spawnRotation = Quaternion.identity; //identity means no rotation is applied
                Instantiate (balls, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait); //delay spawn time via Coroutine           
            }
            yield return new WaitForSeconds (waveWait); //delay time between waves

            //give option for player to restart
            if (gameOver)
            {
                restartText.text = "Press 'R' to restart.";
                restart = true;
                break;
            }
        }
    }

    IEnumerator SpawnSpinner() //Example of a Coroutine to suspend code exectuion so it only runs at intervals of the game
    {
        yield return new WaitForSeconds(startSpinnerWait); //delay first wave by a few seconds

        while (true)
        {            
            Quaternion spawnRotation = Quaternion.identity; //identity means no rotation is applied
            Instantiate(spinner, spinnerPosition, spawnRotation);
            respawnSpinnerWait = Random.Range(10 + spin.lifetime, 20 + spin.lifetime); //randomize Spinner respawn time within game session
            //respawnSpinnerWait = Random.Range(25, 35);
            yield return new WaitForSeconds(respawnSpinnerWait); //delay time between respawn

            //give option for player to restart
            if (gameOver)
            {
                restartText.text = "Press 'R' to restart.";
                restart = true;
                break;
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0; //<-- stops time in the game, other numbers control the flow of time

            //pause all players' controls
            player1.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<PlayerController>().enabled = false;
            player3.GetComponent<PlayerController>().enabled = false;
            player4.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1; //resume game

            //resume all players' controls
            player1.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<PlayerController>().enabled = true;
            player3.GetComponent<PlayerController>().enabled = true;
            player4.GetComponent<PlayerController>().enabled = true;
        }
    }

    public void RailCount(int newRailCount)
    {
        nRails += newRailCount;

        //end the game if total of 3 Players/CPUs lost
        if (nRails == 3)
        {
            GameOver();
        }
    }
}
