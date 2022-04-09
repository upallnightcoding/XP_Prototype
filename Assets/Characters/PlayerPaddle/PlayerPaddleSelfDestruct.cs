using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleSelfDestruct : SelfDestruct
{
    public override void renew()
    {

    }

    public override void selfDestruct(string missileName)
    {
        GameEvents.GetInstance().UpdateScore(missileName, 5);
    }
}
