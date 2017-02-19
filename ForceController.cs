using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour {

    public float lifetime;
    public Vector3 expansionRate;
    
    void Start()
    {        
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //expanding force wave over object's lifetime
        transform.localScale += expansionRate; 
    }
}
