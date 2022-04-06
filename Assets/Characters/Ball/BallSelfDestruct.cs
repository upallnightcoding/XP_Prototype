using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelfDestruct : SelfDestruct
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float ballSpeed;
    [SerializeField] private GameObject theBall;

    public override void selfDestruct(string missileName)
    {
        gameObject.SetActive(false);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        GameEvents.GetInstance().ScoreUpdate(missileName, 10);
    }

    public override void renew()
    {
        StartBall();

        //Destroy(gameObject);
    }

    private void StartBall()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;

        transform.position = new Vector3(0.0f, 0.336f, 0.0f);
        //GameObject newBall = Instantiate(theBall, new Vector3(0.0f, 0.336f, 0.0f), Quaternion.identity);

        theBall.GetComponent<Rigidbody>().velocity = new Vector3(sx, 0.0f, sz) * ballSpeed;
        gameObject.SetActive(true);
    }
}
