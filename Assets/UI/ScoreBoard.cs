using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PlayerOrComputer
{
    COMPUTER,
    PLAYER
}

public enum LivesOrPoints
{
    LIVES,
    POINTS
}

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI computerScore_Txt;
    [SerializeField] private TextMeshProUGUI computerCount_Txt;

    [SerializeField] private TextMeshProUGUI playerScore_Txt;
    [SerializeField] private TextMeshProUGUI playerCount_Txt;

    private int computerScore = 0;
    private int computerLives = 5;

    private int playerScore = 0;
    private int playerLives = 5;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.GetInstance().onUpdateScore += UpdateScore;
        //GameEvents.GetInstance().onUpdateLives += UpdateLives;

        //UpdateScore(new ScorePoints(GameConstants.PLAYER_MISSILE, playerScore));
        //UpdateScore(new ScorePoints(GameConstants.COMPUTER_MISSILE, computerScore));

        //UpdateLives(new ScoreLives(GameConstants.PLAYER_MISSILE, playerLives));
        //UpdateLives(new ScoreLives(GameConstants.COMPUTER_MISSILE, computerLives));
    }

    public void UpdateScore(ScorePoints scorePoints)
    {
        switch(scorePoints.Who)
        {
            case PlayerOrComputer.COMPUTER:
                switch(scorePoints.Element)
                {
                    case LivesOrPoints.LIVES:
                        computerLives += scorePoints.Value;
                        computerCount_Txt.SetText(computerLives.ToString());
                        break;
                    case LivesOrPoints.POINTS:
                        computerScore += scorePoints.Value;
                        computerScore_Txt.SetText(computerScore.ToString());
                        break;
                }
               
                break;
            case PlayerOrComputer.PLAYER:
                switch (scorePoints.Element)
                {
                    case LivesOrPoints.LIVES:
                        playerLives += scorePoints.Value;
                        playerCount_Txt.SetText(playerLives.ToString());
                        break;
                    case LivesOrPoints.POINTS:
                        playerScore += scorePoints.Value;
                        playerScore_Txt.SetText(playerScore.ToString());
                        break;
                }
               
                break;
        }

    }

    /* public void UpdateLives(ScoreLives scoreLives)
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
    }*/
}
