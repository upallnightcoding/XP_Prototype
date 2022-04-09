using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSelfDestruct : SelfDestruct
{
    public override void renew()
    {
        
    }

    public override void selfDestruct(string missileName)
    {
        GameEvents.GetInstance().UpdateScore(missileName, 2);

        Destroy(gameObject);
    }
}
