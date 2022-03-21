using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float bounceStrength = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 normal = collision.GetContact(0).normal;

            ball.GetComponent<Rigidbody>().AddForce(-normal * bounceStrength);
        }

    }*/

}
