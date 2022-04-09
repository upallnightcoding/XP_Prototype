public class ScoreLives
{
    public string Who { get; private set; }
    public int Lives { get; private set; }

    public ScoreLives(string who, int lives)
    {
        Who = who;
        Lives = lives;
    }
}
