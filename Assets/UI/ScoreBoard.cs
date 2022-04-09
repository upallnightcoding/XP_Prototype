using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI computerScore_Txt;
    [SerializeField] private TextMeshProUGUI playerScore_Txt;

    [SerializeField] private TextMeshProUGUI computerLives_Txt;
    [SerializeField] private TextMeshProUGUI playerLives_Txt;

    private int computerScore = 0;
    private int playerScore = 0;

    private int computerLives = 5;
    private int playerLives = 5;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.GetInstance().onUpdateScore += UpdateScore;
        GameEvents.GetInstance().onUpdateLives += UpdateLives;

        UpdateScore(new ScorePoints(GameConstants.PLAYER_MISSILE, playerScore));
        UpdateScore(new ScorePoints(GameConstants.COMPUTER_MISSILE, computerScore));

        UpdateLives(new ScoreLives(GameConstants.PLAYER_MISSILE, playerLives));
        UpdateLives(new ScoreLives(GameConstants.COMPUTER_MISSILE, computerLives));
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

    public void UpdateLives(ScoreLives scoreLives)
    {
        switch (scoreLives.Who)
        {
            case GameConstants.PLAYER_PADDLE_FIELDGOAL:
                playerLives += scoreLives.Lives;
                playerLives_Txt.SetText(playerLives.ToString());
                break;
            case GameConstants.COMPUTER_PADDLE_FIELDGOAL:
                computerLives += scoreLives.Lives;
                computerLives_Txt.SetText(computerLives.ToString());
                break;
        }
    }
}
