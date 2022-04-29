using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grotesque : MonoBehaviour
{
    private const string ANIMATION_STATE_ID = "stateId";

    [SerializeField] private int density;
    [SerializeField] private GameObject brickWallPreFab;
    [SerializeField] private GameObject buildWallPoint;

    private Animator animator;

    private GrotState state = GrotState.HIDING;

    private float startTime = 0;

    private float hideTime = 2.0f;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case GrotState.HIDING:
                state = Hiding();
                break;
            case GrotState.SPAWNING:
                break;
            case GrotState.CREATE_A_TARGET:
                state = CreateATarget();
                break;
            case GrotState.TURN_TOWARDS_TARGET:
                state = TurnTowardsTarget();
                break;
            case GrotState.WALK_TO_TARGET:
                state = WalkToTarget();
                break;
            case GrotState.TURN_TO_BUILD_WALL:
                state = TurnToBuildWall();
                break;
            case GrotState.BUILD_WALL:
                state = BuildWall();
                break;
        }
    }

    public void FinishedSpawning()
    {
        state = GrotState.CREATE_A_TARGET;
    }

    private GrotState Hiding()
    {
        GrotState state = GrotState.HIDING;

        if (Time.time > (startTime + hideTime))
        {
            animator.SetInteger(ANIMATION_STATE_ID, (int) GrotState.SPAWNING);
            state = GrotState.SPAWNING;
        }

        return(state);
    }

    private GrotState CreateATarget()
    {
        Vector2 randomPoint = Random.insideUnitCircle * 6.0f;
        target.x = randomPoint.x;
        target.y = 0.0f;
        target.z = randomPoint.y;

        animator.SetInteger(ANIMATION_STATE_ID, (int) GrotState.WALK);

        return (GrotState.TURN_TOWARDS_TARGET);
    }

    private GrotState TurnTowardsTarget()
    {
        Vector3 direction = target - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 1 * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        float angle = Vector3.Angle(direction, transform.forward);

        return ((angle < 0.1) ? GrotState.WALK_TO_TARGET : GrotState.TURN_TOWARDS_TARGET);
    }

    private GrotState WalkToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 1.1f * Time.deltaTime);

        GrotState state = GrotState.WALK_TO_TARGET;

        float dist = Vector3.Distance(transform.position, target);
        Debug.Log($"Distance: {dist}");

        if (dist < 0.1f)
        {
            state = GrotState.TURN_TO_BUILD_WALL;
        }

        return (state);
    }

    private GrotState TurnToBuildWall()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 1 * Time.deltaTime, 0.0f);

        float angle = Vector3.Angle(direction, transform.forward);
        Debug.Log($"Angle: {angle} ");

        transform.rotation = Quaternion.LookRotation(newDirection);

        return ((angle < 0.1) ? GrotState.BUILD_WALL : GrotState.TURN_TO_BUILD_WALL);
    }

    private GrotState BuildWall()
    {
        Instantiate(brickWallPreFab, buildWallPoint.transform.position, Quaternion.identity);

        return (GrotState.CREATE_A_TARGET);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(target, 0.25f);
    }
}

public enum GrotState
{
    WALK_TO_TARGET          = 1,
    SPAWNING                = 2,
    BUILD_WALL              = 3,
    HIDING                  = 4,
    CREATE_A_TARGET         = 5,
    TURN_TOWARDS_TARGET     = 6,
    WALK                    = 7, 
    TURN_TO_BUILD_WALL      = 11
}
