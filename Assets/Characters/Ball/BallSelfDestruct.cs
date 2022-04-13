using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelfDestruct : SelfDestruct
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float ballSpeed;
    [SerializeField] private GameObject theBall;

    public override void selfDestruct(string name)
    {
        Debug.Log($"Ball Self Destruct: {name}");

        gameObject.SetActive(false);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);

        switch(name)
        {
            case GameConstants.COMPUTER_PADDLE_FIELDGOAL:
                GameEvents.GetInstance().UpdateScore(PlayerOrComputer.COMPUTER, LivesOrPoints.LIVES, -1);
                break;
            case GameConstants.PLAYER_PADDLE_FIELDGOAL:
                GameEvents.GetInstance().UpdateScore(PlayerOrComputer.PLAYER, LivesOrPoints.LIVES, -1);
                break;
            case GameConstants.PLAYER_MISSILE:
                GameEvents.GetInstance().UpdateScore(PlayerOrComputer.PLAYER, LivesOrPoints.POINTS, 10);
                break;
            case GameConstants.COMPUTER_MISSILE:
                GameEvents.GetInstance().UpdateScore(PlayerOrComputer.COMPUTER, LivesOrPoints.POINTS, 10);
                break;
        }
    }

    public override void renew()
    {
        StartBall();
    }

    private void StartBall()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;

        transform.position = new Vector3(0.0f, 0.336f, 0.0f);

        theBall.GetComponent<Rigidbody>().velocity = new Vector3(sx, 0.0f, sz) * ballSpeed;
        gameObject.SetActive(true);
    }
}
