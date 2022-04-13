public class ScorePoints 
{
    public PlayerOrComputer Who { get; private set; }
    public LivesOrPoints Element { get; private set; }
    public int Value { get; private set; }

    public ScorePoints(PlayerOrComputer who, LivesOrPoints element, int value)
    {
        Who = who;
        Element = element;
        Value = value;
    }
}
