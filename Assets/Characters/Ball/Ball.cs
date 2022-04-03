using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] private ParticleSystem explosion;

    private Rigidbody rb = null;
    private SelfDestruct sd = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sd = GetComponent<SelfDestruct>();

        StartBall();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"Ball Collision: {collision.gameObject.name}");

        switch(collision.gameObject.name)
        {
            case GameConstants.COMPUTER_PADDLE_FIELDGOAL:
                sd.selfDestruct(GameConstants.PLAYER_MISSILE);
                break;
            case GameConstants.PLAYER_PADDLE_FIELDGOAL:
                sd.selfDestruct(GameConstants.COMPUTER_MISSILE);
                break;
            case "RightWall":
            case "LeftWall":
                Vector3 normal = collision.GetContact(0).normal;
                rb.AddForce(normal * 2);
                break;
        }
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
