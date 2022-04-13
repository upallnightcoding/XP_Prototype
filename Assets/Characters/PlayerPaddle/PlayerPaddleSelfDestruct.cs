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
        switch (missileName)
        {
            case GameConstants.PLAYER_MISSILE:
                GameEvents.GetInstance().UpdateScore(PlayerOrComputer.PLAYER, LivesOrPoints.POINTS, 5);
                break;
            case GameConstants.COMPUTER_MISSILE:
                GameEvents.GetInstance().UpdateScore(PlayerOrComputer.COMPUTER, LivesOrPoints.POINTS, 5);
                break;
        }
    }
}
