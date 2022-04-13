using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    //public event Action onBallExplosion;
    public event Action<ScorePoints> onUpdateScore;

    void Start()
    {
        instance = this;
    }

    public static GameEvents GetInstance()
    {
        return (instance);
    }

    public void UpdateScore(PlayerOrComputer who, LivesOrPoints element, int value) => 
        onUpdateScore?.Invoke(new ScorePoints(who, element, value));
}
