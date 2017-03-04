using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    public GameObject hazards;
    public Transform spawnPosition;
    public float speedCap; //rotation speed limit
    public float adjust; //speed offset
    public float incrementMod; //rate of speed offset increase
    public float lifetime; //duration of activity
    public float startWait;
    public float spawnWait;
    public Vector3 rotationRate; //initial rotation value    

    void Start()
    {
        Destroy(gameObject, lifetime);
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        //increasing spin rate over object's lifetime
        transform.localRotation *= Quaternion.Euler(rotationRate * Time.deltaTime * adjust);
        adjust = adjust + incrementMod;
        
        if(adjust > speedCap) { adjust = speedCap; }
    }

    IEnumerator SpawnWaves() //Example of a Coroutine to suspend code exectuion so it only runs at intervals of the game
    {
        yield return new WaitForSeconds(startWait); //delay first wave by a few seconds
        while (true)
        {
            Quaternion spawnRotation = Quaternion.identity; //identity means no rotation is applied
            Instantiate(hazards, spawnPosition.position, spawnRotation);
            yield return new WaitForSeconds(spawnWait); //delay spawn time via Coroutine           
                        
        }
    }
}
