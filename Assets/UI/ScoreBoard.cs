using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI computerScore_Txt;
    [SerializeField] private TextMeshProUGUI playerScore_Txt;

    private int computerScore = 0;
    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.GetInstance().onScoreUpdate += UpdateScore;
    }

    public void UpdateScore(ScorePoints scorePoints)
    {
        switch(scorePoints.Who)
        {
            case GameConstants.PLAYER_MISSILE:
                playerScore += scorePoints.Points;
                playerScore_Txt.SetText(playerScore.ToString());
                break;
            case GameConstants.COMPUTER_MISSILE:
                computerScore += scorePoints.Points;
                computerScore_Txt.SetText(computerScore.ToString());
                break;
        }

    }
}
