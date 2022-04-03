using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelfDestruct : SelfDestruct
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float ballSpeed; 

    private Rigidbody rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartBall();
    }

    public override void selfDestruct(string missileName)
    {
        gameObject.SetActive(false);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        GameEvents.GetInstance().ScoreUpdate(missileName, 10);
        StartBall();
    }

    public override void renew()
    {
        StartBall();
    }

    private void StartBall()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector3(sx, 0.0f, sz) * ballSpeed;
        transform.position = new Vector3(0.0f, 0.336f, 0.0f);
        gameObject.SetActive(true);
    }
}
