using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour
{
    //adjust speed range of ball impulse force
    public float augment;

    private Vector3 initialImpulse;
    private int pulsePoint;
    

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CheckPulse();

        //use case-switch with spawnValue to decide spawn position
        switch (pulsePoint)
        {
            case 0:
                //shoot from NE cannon w/random angling
                initialImpulse = new Vector3 ((Random.Range(-10, -15)) * augment, 0f, (Random.Range(-10, -15)) * augment);
                break;

            case 1:
                //shoot from NW cannon w/random angling
                initialImpulse = new Vector3 ((Random.Range(10, 15)) * augment, 0f, (Random.Range(-10, -15)) * augment);
                break;

            case 2:
                //shoot from SW cannon w/random angling
                initialImpulse = new Vector3 ((Random.Range(10, 15)) * augment, 0f, (Random.Range(10, 15)) * augment);
                break;

            default:
                //shoot from SE cannon w/random angling
                initialImpulse = new Vector3 ((Random.Range(-10, -15)) * augment, 0f, (Random.Range(10, 15)) * augment);
                break;
        }

        //shoot the ball as it spawns
        rb.AddForce(initialImpulse, ForceMode.Impulse);
    }

    //Determines the correct ball force direction
    void CheckPulse()
    {
        if (transform.position == new Vector3 (12f, 6f, 12f))
        {
            pulsePoint = 0;
        }
        else if (transform.position == new Vector3 (-12f, 6f, 12f))
        {
            pulsePoint = 1;
        }
        else if (transform.position == new Vector3 (-12f, 6f, -12f))
        {
            pulsePoint = 2;
        }
        else
        {
            pulsePoint = 3;
        }
    }
}



