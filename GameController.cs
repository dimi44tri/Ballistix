//Handles the logic behind spawning hazards
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject hazards;
    
    public int hazardCount;
    public float startWait;
    public float spawnWait;    
    public float waveWait;    

    //public GUIText scoreText;
    //public GUIText restartText;
    //public GUIText gameOverText;

    //private int score;
    //private bool gameOver;
    //private bool restart;

    private Vector3 spawnPosition;



    // Use this for initialization
    void Start()
    {
        /*gameOver = restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();*/

        //sets randomized spawn points for balls
        StartCoroutine(SpawnWaves());
    }

    //void Update()
    //{
    //    //check for R input and restart current (or a specified) scene
    //    if (restart)
    //    {
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    //            /* 'UnityEngine.SceneManagement.SceneManager.LoadScene(0);' <---this also works*/
    //        }
    //    }

    //}

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
                        spawnPosition = new Vector3 (12f, 6f, 12f);                                            
                        break;

                    case 1:
                        //shoot from NW cannon
                        spawnPosition = new Vector3 (-12f, 6f, 12f);
                        break;

                    case 2:
                        //shoot from SW cannon
                        spawnPosition = new Vector3 (-12f, 6f, -12f);
                        break;

                    default:
                        //shoot from SE cannon
                        spawnPosition = new Vector3 (12f, 6f, -12f);
                        break;
                }
                Quaternion spawnRotation = Quaternion.identity; //identity means no rotation is applied
                Instantiate (hazards, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait); //delay spawn time via Coroutine           
            }
            yield return new WaitForSeconds (waveWait); //delay time between waves

            /*if (gameOver)
            {
                restartText.text = "Press 'R' to restart.";
                restart = true;
                break;
            }*/
        }
    }

    //public void AddScore(int newScoreValue)
    //{
    //    score += newScoreValue;
    //    UpdateScore();
    //}

    //public void GameOver()
    //{
    //    gameOverText.text = "Game Over!";
    //    gameOver = true;
    //}

    //void UpdateScore()
    //{
    //    scoreText.text = "Score: " + score; //score is automaticaly cast to string
    //}
}
