using UnityEngine;
using System.Collections;


//player identifier attribute in editor
public enum ePlayer {
    Up,
    Down,
    Left,
    Right
}

[System.Serializable] //<-- Makes the below class show up as a new property in the unity inspector
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;    
    public ePlayer Player;

    void FixedUpdate()
    {
        float inputDirection = 0; //direction of player input relative to player ID
        switch (Player)
        {
            case ePlayer.Down:
                //Referencing custom virtual input settings from editor
                inputDirection = Input.GetAxisRaw("Player1");
                //Not using physics engine --- time property used to standardize motion timing across different devices
                transform.position += new Vector3(inputDirection * speed * Time.deltaTime, 0, 0);
                break;

            case ePlayer.Up:
                inputDirection = Input.GetAxisRaw("Player2");
                transform.position += new Vector3(inputDirection * speed * Time.deltaTime, 0, 0);
                break;

            case ePlayer.Left:
                inputDirection = Input.GetAxisRaw("Player3");
                transform.position += new Vector3(0, 0, inputDirection * speed * Time.deltaTime);
                break;

            default:
                inputDirection = Input.GetAxisRaw("Player4");
                transform.position += new Vector3(0, 0, inputDirection * speed * Time.deltaTime);
                break;
        }


    }






    
    ////Rigidbody variable to capture the same-named component from Player sphere object in unity
    //public float speed;
    //private Rigidbody rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();

    //}

    ////Fixed update used applying forces
    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");

    //    //y is zero since player isn't moving up off the plane
    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

    //    //apply a force to sphere based on received Input (for kinematic setting)
    //    rb.AddForce(movement * speed);

    //}
}
