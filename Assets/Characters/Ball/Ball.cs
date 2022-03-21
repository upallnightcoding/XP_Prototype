using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 5;
    [SerializeField] private ParticleSystem explosion;

    private Rigidbody rb = null;

    public void AddForce()
    {

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartBall();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision: " + collision.gameObject.tag);

        switch(collision.gameObject.tag)
        {
            case "FieldGoal":
            case "Missile":
                gameObject.SetActive(false);
                ParticleSystem ps = Instantiate(explosion, gameObject.transform.position, Quaternion.identity) as ParticleSystem;
                transform.position = new Vector3(0.0f, 0.336f, 0.0f);
                StartBall();
                gameObject.SetActive(true);
                break;
            case "Wall":
                Vector3 normal = collision.GetContact(0).normal;
                rb.AddForce(normal);
                break;
        }
    }

    private void StartBall()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector3(sx, 0.0f, sz) * ballSpeed;
    }
}
