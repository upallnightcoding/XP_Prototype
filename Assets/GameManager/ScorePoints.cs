public class ScorePoints 
{
    public string Who { get; private set; }
    public int Points { get; private set; }

    public ScorePoints(string who, int points)
    {
        Who = who;
        Points = points;
    }
}
