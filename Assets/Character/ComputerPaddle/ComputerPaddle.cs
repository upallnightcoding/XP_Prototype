using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    [SerializeField] private Rigidbody ball;

    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball.velocity.x > 0.0f)
        {
            rb.AddForce(new Vector3(10.0f, 0.0f, 0.0f));
        } else
        {
            rb.AddForce(new Vector3(-10.0f, 0.0f, 0.0f));
        }
    }
}
