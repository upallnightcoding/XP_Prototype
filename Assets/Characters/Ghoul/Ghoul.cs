using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    [SerializeField] private int density;

    private Animator animator;

    private GhoulState state = GhoulState.HIDDEN;
    private GameObject coinTarget = null;
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
                animator.SetInteger("stateId", (int)GhoulState.SPAWN);
                state = GhoulState.SEARCH;
                break;
            case GhoulState.SEARCH:
                coinTarget = Search();

                if (coinTarget != null)
                {
                    animator.SetInteger("stateId", (int)GhoulState.WALK);
                    state = GhoulState.TURN;
                } 

                break;
            case GhoulState.TURN:
                if (coinTarget != null)
                {
                    Vector3 direction = coinTarget.transform.position - transform.position;
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 1 * Time.deltaTime, 0.0f);

                    float angle = Vector3.Angle(direction, transform.forward);

                    if (angle < 0.5)
                    {
                        state = GhoulState.WALK;
                    } 

                    transform.rotation = Quaternion.LookRotation(newDirection);
                }
                break;
            case GhoulState.WALK:
                if (coinTarget != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, coinTarget.transform.position, step * Time.deltaTime);
                    state = (Vector3.Distance(transform.position, coinTarget.transform.position) < 1.2f) ? GhoulState.PICKUP : GhoulState.WALK;
                }
                else
                {
                    state = GhoulState.SEARCH;
                }
                break;
            case GhoulState.PICKUP:
                animator.SetInteger("stateId", (int)GhoulState.PICKUP);
                state = GhoulState.WAITPICKUP;

                break;
            case GhoulState.WAITPICKUP:
                if (coinTarget != null)
                {
                    Destroy(coinTarget);
                    coinTarget = null;
                }
                state = AnimatorIsPlaying() ? GhoulState.WAITPICKUP : GhoulState.SEARCH;
                //state = GhoulState.SEARCH;
                break;
            case GhoulState.DISSOLVE:
                break;
        }

        Debug.Log($"State: {state}");
    }

    private bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private GameObject Search()
    {
        GameObject target = null;

        var allCoins = GameObject.FindGameObjectsWithTag("Coin");

        if (allCoins.Length > 0)
        {
            int select = Random.Range(0, allCoins.Length - 1);
            target = allCoins[select];    
        }

        return (target);
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
