using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTrigger : MonoBehaviour {

    public float fireRate;
    public GameObject force;
    public Transform forceSpawn;

    private float nextFire;

    //Reference the object we are colliding with and trigger force ability
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(force, forceSpawn.position, forceSpawn.rotation);
        }
    }
}
