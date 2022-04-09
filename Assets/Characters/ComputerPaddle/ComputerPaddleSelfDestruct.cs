using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddleSelfDestruct : SelfDestruct
{
    public override void renew()
    {

    }

    public override void selfDestruct(string missileName)
    {
        GameEvents.GetInstance().UpdateScore(missileName, 5);
    }

}
