using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Coin coin = collision.gameObject.GetComponent<Coin>();

        if (coin != null)
        {
            coin.DestroySelf();
        }

        Destroy(gameObject);
    }

}
