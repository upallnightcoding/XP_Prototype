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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(ScorePoints scorePoints)
    {
        //Debug.Log($"Who: {scorePoints.Who} Points: {scorePoints.Points}");

        switch(scorePoints.Who)
        {
            case GameConstants.PLAYER_PADDLE_FIELDGOAL:
                playerScore += scorePoints.Points;
                playerScore_Txt.SetText(playerScore.ToString());
                break;
            case GameConstants.COMPUTER_PADDLE_FIELDGOAL:
                computerScore += scorePoints.Points;
                computerScore_Txt.SetText(computerScore.ToString());
                break;
        }

    }
}
