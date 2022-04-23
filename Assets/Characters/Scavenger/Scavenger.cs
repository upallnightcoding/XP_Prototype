using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject fireBallPreFab;

    public void ThrowFireBall()
    {
        GameObject fileBall = Instantiate(fireBallPreFab, firePoint.transform.position, Quaternion.identity);
        fileBall.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -150.0f));
    }
}
