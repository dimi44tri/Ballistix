using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //<-- namespace for the HUD

public class DestroyLife : MonoBehaviour {

    public bool playerSpace;
    public bool cpuSpace;
    public Text life;
    public float plifePoints;
    public float clifePoints;
    public int player;
    public int cpu;
    public GameObject rail;
    public Transform railSpace;

    private GameController gameController;
    public float customLivesP;
    public float customLivesC;
    private bool railCheck1; 
    private bool railCheck2;
    private bool railCheck3;
    private bool railCheck4;


    void Start()
    {
        railCheck1 = railCheck2 = railCheck3 = railCheck4 = false;

        //allows each boundary to have access to GameOver function in GameController
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        //confirm if text is for a player or for a cpu
        LifeSpace();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //Destroy ball
            Destroy(other.gameObject);
            plifePoints--;
            clifePoints--;

            //cap at 0 lifePoints
            if (plifePoints < 0) { plifePoints = 0; }
            if (clifePoints < 0) { clifePoints = 0; }

            //update life points
            LifeSpace();

            //If a player lost, generate railing
            CreateRail();
        }
    }

    void LifeSpace()
    {
        if (playerSpace)
        {
            life.text = "Player " + player.ToString() + ": " + plifePoints.ToString();
        }
        else
        {
            life.text = "CPU " + cpu.ToString() + ": " + clifePoints.ToString();
        }
    }

    void CreateRail()
    {
        //spawn the south rail when player loses
        if (life.text == "CPU 4: 0" || life.text == "Player 1: 0")
        {
            if (railCheck1 == false)
            {
                railSpace.position = new Vector3(14.5f, 2.5f, -17);
                railSpace.rotation = Quaternion.identity;
                Instantiate(rail, railSpace.position, railSpace.rotation);
                gameController.RailCount(1);

                //prevent additional rails from accidentally spawning
                railCheck1 = true;
            }            
        }

        //spawn the north rail when player loses
        if (life.text == "CPU 1: 0" || life.text == "Player 2: 0")
        {
            if (railCheck2 == false)
            {
                railSpace.position = new Vector3(14.5f, 2.5f, 17);
                railSpace.rotation = Quaternion.identity;
                Instantiate(rail, railSpace.position, railSpace.rotation);
                gameController.RailCount(1);

                //prevent additional rails from accidentally spawning
                railCheck2 = true;
            }
        }

        //spawn the west rail when player loses
        if (life.text == "CPU 2: 0" || life.text == "Player 3: 0")
        {
            if (railCheck3 == false)
            {
                railSpace.position = new Vector3(-17, 2.5f, -14.5f);
                railSpace.rotation = Quaternion.Euler(0, 90, 0);
                Instantiate(rail, railSpace.position, railSpace.rotation);
                gameController.RailCount(1);

                //prevent additional rails from accidentally spawning
                railCheck3 = true;
            }
        }

        //spawn the east rail when player loses
        if (life.text == "CPU 3: 0" || life.text == "Player 4: 0")
        {
            if (railCheck4 == false)
            {
                railSpace.position = new Vector3(17, 2.5f, -14.5f);
                railSpace.rotation = Quaternion.Euler(180, 90, 0);
                Instantiate(rail, railSpace.position, railSpace.rotation);
                gameController.RailCount(1);

                //prevent additional rails from accidentally spawning
                railCheck4 = true;
            }
        }

    }

    public void AssignPlayerLives (float pAssigned)
    {
        plifePoints = pAssigned;
        customLivesP = pAssigned;
    }

    public void AssignCPULives(float cAssigned)
    {
        clifePoints = cAssigned;
        customLivesC = cAssigned;
    }

    //store the assigned custom lives from main menu for game restart
    public float SavePlayer()
    {
        return customLivesP;
    }

    //store the assigned custom lives from main menu for game restart
    public float SaveCPU()
    {
        return customLivesC;
    }
}
