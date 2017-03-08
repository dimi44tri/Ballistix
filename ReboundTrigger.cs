using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundTrigger : MonoBehaviour {

    public float speed;

    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rbBall; //parent ball
    private Transform rbForce; //colliding force object
    private AudioSource[] ReboundSfx;

    void Start()
    {        
        rbBall = GetComponentInParent<Rigidbody>();
        ReboundSfx = GetComponents<AudioSource>();
    }

    //Reference the object we are colliding with and trigger force ability
    void OnTriggerEnter(Collider other)
    {
        //SFX for corresponding Ball Contact
        ContactAudio(other);

        //deflect ball at high speed in relation to Player 1/AI 4 location on world space
        if (other.gameObject.CompareTag("Force")
            && other.gameObject.transform.position.z < 0.0f
            && other.gameObject.transform.position.x < 16.0f
            && other.gameObject.transform.position.x > -16.0f)
        {
            rbForce = other.GetComponent<Transform>();
            moveHorizontal = rbBall.transform.position.x;

            //is ball in front of force contact or behind it
            if (rbBall.transform.position.z < rbForce.transform.position.z)
            {
                moveVertical = rbForce.transform.position.z;
            }
            if (rbBall.transform.position.z > rbForce.transform.position.z)
            {
                moveVertical = -rbForce.transform.position.z;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rbBall.AddForce(movement * speed);
        }

        //deflect ball at high speed in relation to Player 2/AI 1 location on world space
        if (other.gameObject.CompareTag("Force")
            && other.gameObject.transform.position.z > 0.0f
            && other.gameObject.transform.position.x < 16.0f
            && other.gameObject.transform.position.x > -16.0f)
        {
            rbForce = other.GetComponent<Transform>();
            moveHorizontal = rbBall.transform.position.x;

            //is ball in front of force contact or behind it
            if (rbBall.transform.position.z < rbForce.transform.position.z)
            {
                moveVertical = -rbForce.transform.position.z;
            }
            if (rbBall.transform.position.z > rbForce.transform.position.z)
            {
                moveVertical = rbForce.transform.position.z;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rbBall.AddForce(movement * speed);
        }

        //deflect ball at high speed in relation to Player 3 / AI 2 location on world space
        if (other.gameObject.CompareTag("Force") 
            && other.gameObject.transform.position.x < 0.0f 
            && other.gameObject.transform.position.z < 16.0f 
            && other.gameObject.transform.position.z > -16.0f)
        {
            rbForce = other.GetComponent<Transform>();
            moveVertical = rbBall.transform.position.z;

            //is ball in front of force contact or behind it
            if (rbBall.transform.position.x < rbForce.transform.position.x)
            {
                moveHorizontal = rbForce.transform.position.x;
            }
            if (rbBall.transform.position.x > rbForce.transform.position.x)
            {
                moveHorizontal = -rbForce.transform.position.x;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rbBall.AddForce(movement * speed);
        }

        //deflect ball at high speed in relation to Player 4 / AI 3 location on world space
        if (other.gameObject.CompareTag("Force")
            && other.gameObject.transform.position.x > 0.0f
            && other.gameObject.transform.position.z < 16.0f
            && other.gameObject.transform.position.z > -16.0f)
        { 
            rbForce = other.GetComponent<Transform>();
            moveVertical = rbBall.transform.position.z;

            //is ball in front of force contact or behind it
            if (rbBall.transform.position.x < rbForce.transform.position.x)
            {
                moveHorizontal = -rbForce.transform.position.x;
            }
            if (rbBall.transform.position.x > rbForce.transform.position.x)
            {
                moveHorizontal = rbForce.transform.position.x;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rbBall.AddForce(movement * speed);
        }
    }

    void ContactAudio(Collider other)
    {
        if (other.gameObject.CompareTag("Goal")) { ReboundSfx[0].Play(); }
        if (other.gameObject.CompareTag("Force")) { ReboundSfx[1].Play(); }
        if (other.gameObject.CompareTag("Corner") || other.gameObject.CompareTag("Wall")) { ReboundSfx[2].Play(); }

    }
}
