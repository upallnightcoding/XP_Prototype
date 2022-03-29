using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    /*****************/
    /*** Inspector ***/
    /*****************/

    [SerializeField] private float paddleSpeed;
    [SerializeField] private float missileSpeed;
    [SerializeField] private GameObject missile;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private int safeGuard;

    // Paddle Name 
    private string paddleName = null;

    private int missileCount = 0;

    //--------------------------------------------------------

    private Rigidbody rigidBody = null;

    private float strafing;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        paddleName = gameObject.name;
    }

    private void Update()
    {
        strafing = Input.GetAxisRaw(paddleName);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            missileCount++;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StrafingPaddle();

        if (missileCount > 0)
        {
            FireMissile();
        }

    }

    private void FireMissile()
    {
        missileCount--;

        GameObject currentMissile = Instantiate(missile, muzzle.transform.position, Quaternion.identity);

        currentMissile.GetComponent<Rigidbody>().AddForce(Vector3.forward * missileSpeed, ForceMode.Impulse);

        currentMissile.name = GameConstants.PLAYER_MISSILE;
    }

    private void StrafingPaddle()
    {
        rigidBody.AddForce(new Vector3(strafing, 0.0f, 0.0f) * paddleSpeed);

        if (Math.Abs(transform.position.x) > safeGuard)
        {
            float x = transform.position.x * -1.0f;

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
