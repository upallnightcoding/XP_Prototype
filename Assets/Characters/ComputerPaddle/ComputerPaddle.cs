using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    [SerializeField] private Rigidbody ball;
    [SerializeField] private float paddleSpeed;
    [SerializeField] private GameObject missile;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float missileSpeed;
    [SerializeField] private int missileDensity;

    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePaddle();

        RandomShooting();
    }

    private void RandomShooting()
    {
        if (Random.Range(1, missileDensity) == 1)
        {
            GameObject currentMissile = Instantiate(missile, muzzle.transform.position, Quaternion.identity);

            currentMissile.GetComponent<Rigidbody>().AddForce(-Vector3.forward * missileSpeed, ForceMode.Impulse);
        }
    }

    private void MovePaddle()
    {
        if (ball.velocity.z > 0.0f)
        {
            if (ball.velocity.x > 0.0f)
            {
                rb.AddForce(new Vector3(paddleSpeed, 0.0f, 0.0f));
            }
            else
            {
                rb.AddForce(new Vector3(-paddleSpeed, 0.0f, 0.0f));
            }
        }
        else
        {
            if (transform.position.x > 0.0f)
            {
                rb.AddForce(new Vector3(-paddleSpeed, 0.0f, 0.0f));
            }
            else
            {
                rb.AddForce(new Vector3(paddleSpeed, 0.0f, 0.0f));
            }
        }
    }
}
