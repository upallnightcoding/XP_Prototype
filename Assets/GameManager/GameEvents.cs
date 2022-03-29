using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    public event Action onBallExplosion;
    public event Action<ScorePoints> onScoreUpdate;

    private void Awake()
    {
    }

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameEvents GetInstance()
    {
        return (instance);
    }

    public void ScoreUpdate(string who, int points)
    {
        onScoreUpdate?.Invoke(new ScorePoints(who, points));
    }

    public void BallExplosion()
    {
        onBallExplosion?.Invoke();
    }
}
