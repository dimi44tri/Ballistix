﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //<-- namespace for the HUD

public class DestroyLife : MonoBehaviour {

    public bool playerSpace;
    public bool cpuSpace;
    public Text life;
    public int lifePoints;
    public int player;
    public int cpu;
    public GameObject rail;
    public Transform railSpace;

    private GameController gameController;

    void Start()
    {
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
            lifePoints--;
            //cap at 0 lifePoints
            if (lifePoints < 0) { lifePoints = 0; }

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
            life.text = "Player " + player.ToString() + ": " + lifePoints.ToString();
        }
        else
        {
            life.text = "CPU " + cpu.ToString() + ": " + lifePoints.ToString();
        }
    }

    void CreateRail()
    {
        //spawn the south rail when player loses
        if (life.text == "CPU 4: 0" || life.text == "Player 1: 0")
        {
            railSpace.position = new Vector3(.1f, 2.5f, -17);
            railSpace.rotation = Quaternion.identity;
            Instantiate(rail, railSpace.position, railSpace.rotation);
            gameController.RailCount(1);
        }

        //spawn the north rail when player loses
        if (life.text == "CPU 1: 0" || life.text == "Player 2: 0")
        {
            railSpace.position = new Vector3(.1f, 2.5f, 17);
            railSpace.rotation = Quaternion.identity;
            Instantiate(rail, railSpace.position, railSpace.rotation);
            gameController.RailCount(1);
        }

        //spawn the west rail when player loses
        if (life.text == "CPU 2: 0" || life.text == "Player 3: 0")
        {
            railSpace.position = new Vector3(-17, 2.5f, 0);
            railSpace.rotation = Quaternion.Euler(0, 90, 0);
            Instantiate(rail, railSpace.position, railSpace.rotation);
            gameController.RailCount(1);
        }

        //spawn the east rail when player loses
        if (life.text == "CPU 3: 0" || life.text == "Player 4: 0")
        {
            railSpace.position = new Vector3(17, 2.5f, 0);
            railSpace.rotation = Quaternion.Euler(180, 90, 0);
            Instantiate(rail, railSpace.position, railSpace.rotation);
            gameController.RailCount(1);
        }

    }
    
}