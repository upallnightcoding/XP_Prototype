using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        SelfDestruct destruct = 
            collision.gameObject.GetComponent<SelfDestruct>();

        if (destruct != null)
        {
            destruct.selfDestruct(name);

            destruct.renew();
        }

        Destroy(gameObject);
    }

}
