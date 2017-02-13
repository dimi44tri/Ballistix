using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour {

    public GameObject force;
    public Transform emission;
    public float emissionRate;
    public float delay;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Emit", delay, emissionRate); //<--calls the Emit function at intervals of the game for current object instance (similar to coroutine)
	}
	
	// Force ability from player
	void Emit () {
        audioSource.Play();
        Instantiate(force, emission.position, emission.rotation);
    }
}
