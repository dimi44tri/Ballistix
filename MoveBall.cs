using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour
{
    //public float speed;
    public Vector3 initialImpulse;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //allows manual control in editor for ball movement
        rb.AddForce(initialImpulse, ForceMode.Impulse);
    }
}

