using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter: " + collision.collider.name);
        Destroy(gameObject);
    }

}
