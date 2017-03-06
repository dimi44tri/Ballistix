using UnityEngine;
using System.Collections;


public class EnemyController : MonoBehaviour
{

    public float distance;
    public float smoothing; //<-- how quickly AI moves into the dodge
    public Vector2 startWait;    
    public Vector2 repellingTime;
    public Vector2 repellingWait;

    private float repelSpot; //<-- potential spot for AI to move to repel balls
    private Rigidbody rb;


    void Start()
    {
        StartCoroutine(Repel());
        rb = GetComponent<Rigidbody>();
    }

    //enumerator for coroutine
    IEnumerator Repel() 
    {
        //randomize wait time before inital movement
        yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

        //movement range controller
        while (true)
        {
            //semi-randomize movement distance and direction tendencies towards center position
            repelSpot = Random.Range(1, distance) * -Mathf.Sign(transform.position.y);
            yield return new WaitForSeconds (Random.Range (repellingTime.x, repellingTime.y));

            //stop and wait again for next movement
            repelSpot = 0;
            yield return new WaitForSeconds (Random.Range (repellingTime.x, repellingTime.y));
        }
    }

    void FixedUpdate()
    {
        float newRepel = Mathf.MoveTowards (rb.velocity.y, repelSpot, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(0.0f, newRepel, 0.0f);
    }
}