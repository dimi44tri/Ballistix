using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterBallMover : MonoBehaviour {
    
    public float speed;

    private Rigidbody rb;
    private GameObject spawnOrientation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnOrientation = GameObject.FindGameObjectWithTag("Ball Spawn");

        //shoot ball forward respective of parent spawn oreitantaion
        rb.velocity = spawnOrientation.transform.forward * speed;
    }
}
