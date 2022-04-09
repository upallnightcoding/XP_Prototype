using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    [SerializeField] private int density;
    [SerializeField] GameObject rockPreFab;

    private Animator animator;

    private GhoulState state = GhoulState.HIDDEN;
    private GameObject boulder = null;
    private float step = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        switch (state)
        {
            case GhoulState.HIDDEN:
                state = (Random.Range(1, density) == 1) ? GhoulState.SPAWN : state;
                break;
            case GhoulState.SPAWN:
                gameObject.SetActive(true);
                animator.Play("spawn");
                state = GhoulState.SEARCH;
                break;
            case GhoulState.SEARCH:
                boulder = SearchForBoulderTarget();

                if (boulder != null)
                {
                    animator.SetInteger("stateId", (int)GhoulState.WALK);
                    state = GhoulState.TURN;
                }

                break;
            case GhoulState.TURN:
                Vector3 direction = boulder.transform.position - transform.position;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 1 * Time.deltaTime, 0.0f);

                float angle = Vector3.Angle(direction, transform.forward);

                if (angle < 0.5)
                {
                    state = GhoulState.WALK;
                } 

                transform.rotation = Quaternion.LookRotation(newDirection);
                break;
            case GhoulState.WALK:
                transform.position = Vector3.MoveTowards(transform.position, boulder.transform.position, step * Time.deltaTime);
                state = (Vector3.Distance(transform.position, boulder.transform.position) < 2.0f) ? GhoulState.PICKUP : GhoulState.WALK;
                break;
            case GhoulState.PICKUP:
                animator.SetInteger("stateId", (int)GhoulState.PICKUP);
                state = GhoulState.WAITPICKUP;
                break;
            case GhoulState.WAITPICKUP:
                break;
            case GhoulState.DISSOLVE:
                break;
        }
        
    }

    private void DestroyCoinAnimationEvent()
    {
        if (boulder != null)
        {
            Destroy(boulder);
            boulder = null;
            state = GhoulState.SEARCH;
        }
    }

    private GameObject SearchForBoulderTarget()
    {
        GameObject boulder = null;

        var nextCoin = GameObject.FindGameObjectWithTag("Coin");

        if (nextCoin != null) 
        {
            boulder = Instantiate(rockPreFab, nextCoin.transform.position, Quaternion.identity);
            Destroy(nextCoin);
        }

        return (boulder);
    }

    private void Approach()
    {

    }
}

public enum GhoulState
{
    HIDDEN      = 0,
    SPAWN       = 1,
    SEARCH      = 2,
    WALK        = 3,
    PICKUP      = 4,
    DISSOLVE    = 5,
    TURN        = 6,
    WAITPICKUP  = 7
}
