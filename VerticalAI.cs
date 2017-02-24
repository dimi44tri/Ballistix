using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class VerticalAI : MonoBehaviour
{
    public int cpuID;
    public float distance;
    public float smoothing; //<-- how quickly AI moves into the dodge
    public Text life;
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
            repelSpot = Random.Range (1, distance) * -Mathf.Sign (transform.position.z);
            yield return new WaitForSeconds (Random.Range (repellingTime.x, repellingTime.y));

            //stop and wait again for next movement
            repelSpot = 0;
            yield return new WaitForSeconds (Random.Range (repellingTime.x, repellingTime.y));
        }
    }

    void Update()
    {
        if (life.text == "CPU " + cpuID.ToString() + ": 0")
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        float newRepel = Mathf.MoveTowards (rb.velocity.z, repelSpot, Time.deltaTime * smoothing);
        rb.velocity = new Vector3 (0, 0, newRepel);
    }
}