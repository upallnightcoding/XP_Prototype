using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    //public event Action onBallExplosion;
    public event Action<ScorePoints> onUpdateScore;
    public event Action<ScoreLives> onUpdateLives;

    void Start()
    {
        instance = this;
    }

    public static GameEvents GetInstance()
    {
        return (instance);
    }

    public void UpdateScore(string who, int points) => onUpdateScore?.Invoke(new ScorePoints(who, points));
    
    public void UpdateLives(string who, int lives) => onUpdateLives?.Invoke(new ScoreLives(who, lives));
}
