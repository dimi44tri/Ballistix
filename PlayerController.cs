using UnityEngine;
using UnityEngine.UI;
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

    public int playerID;
    public float fireRate;
    public float speed;
    public Text life;
    public GameObject force;
    public Transform forceSpawn;    
    public ePlayer Player;

    private float nextFire1;
    private float nextFire2;
    private float nextFire3;
    private float nextFire4;   
  
    void Update()
    {
        //Link Force ability input button to corresponding player ID
        switch (Player)
        {
            //Link Force1 to Player1
            case ePlayer.Down:
                if (Input.GetButton("Force1") && Time.time > nextFire1) //condition to adjust rate/timing of shots
                {
                    nextFire1 = Time.time + fireRate;
                    /*GameObject clone = code below if I want to save a reference to the new object being instantiated*/
                    Instantiate(force, forceSpawn.position, forceSpawn.rotation); /*....as GameObject; //<--when creating this entity, create it as a game object*/
                }
                break;
            //Link Force2 to Player2
            case ePlayer.Up:
                if (Input.GetButton("Force2") && Time.time > nextFire2) //condition to adjust rate/timing of shots
                {
                    nextFire2 = Time.time + fireRate;
                    /*GameObject clone = code below if I want to save a reference to the new object being instantiated*/
                    Instantiate(force, forceSpawn.position, forceSpawn.rotation); /*....as GameObject; //<--when creating this entity, create it as a game object*/
                }
                break;
            //Link Force3 to Player3
            case ePlayer.Left:
                if (Input.GetButton("Force3") && Time.time > nextFire3) //condition to adjust rate/timing of shots
                {
                    nextFire3 = Time.time + fireRate;
                    /*GameObject clone = code below if I want to save a reference to the new object being instantiated*/
                    Instantiate(force, forceSpawn.position, forceSpawn.rotation); /*....as GameObject; //<--when creating this entity, create it as a game object*/
                }
                break;
            //Link Force4 to Player4
            default:
                if (Input.GetButton("Force4") && Time.time > nextFire4) //condition to adjust rate/timing of shots
                {
                    nextFire4 = Time.time + fireRate;
                    /*GameObject clone = code below if I want to save a reference to the new object being instantiated*/
                    Instantiate(force, forceSpawn.position, forceSpawn.rotation); /*....as GameObject; //<--when creating this entity, create it as a game object*/
                }
                break;
        }

        //if player loses all life points, they are removed
        DeadOrAlive();
    }

    void FixedUpdate()
    {
        //direction of player input relative to player ID
        float inputDirection = 0; 
        switch (Player)
        {
            //Link Player1 movement control
            case ePlayer.Down:
                //Referencing custom virtual input settings from editor
                inputDirection = Input.GetAxisRaw("Player1");
                //Not using physics engine --- time property used to standardize motion timing across different devices
                transform.position += new Vector3(inputDirection * speed * Time.deltaTime, 0, 0);
                break;

            //Link Player2 movement control
            case ePlayer.Up:
                inputDirection = Input.GetAxisRaw("Player2");
                transform.position += new Vector3(inputDirection * speed * Time.deltaTime, 0, 0);
                break;

            //Link Player3 movement control
            case ePlayer.Left:
                inputDirection = Input.GetAxisRaw("Player3");
                transform.position += new Vector3(0, 0, inputDirection * speed * Time.deltaTime);
                break;

            //Link Player4 movement control
            default:
                inputDirection = Input.GetAxisRaw("Player4");
                transform.position += new Vector3(0, 0, inputDirection * speed * Time.deltaTime);
                break;
        }
    }

    void DeadOrAlive()
    {        
        if (life.text == "Player " + playerID.ToString() + ": 0")
        {
            Destroy(gameObject);
        }
    }
}