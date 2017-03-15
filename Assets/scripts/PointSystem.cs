public class PointSystem
{
    private static PointSystem instance;
    public static PointSystem Instance
    {
        get { return PointSystem.instance; }
    }

    public static PointSystem Instantiate(int numPlayers)
    {
        return PointSystem.instance = new PointSystem(numPlayers);
    }

    private int[] points;
    public int[] Points
    {
        get { return this.points; }
    }

    private PointSystem(int numberOfPlayers)
    {
        this.points = new int[numberOfPlayers];
    }

    public int GetCurrentPoints(int player)
    {
        return this.points[player - 1];
    }

    public void SetCurrentPoints(int player, int points)
    {
        this.points[player - 1] = points;
    }

    public void AddPoints(int player, int points)
    {
        this.SetCurrentPoints(player, this.GetCurrentPoints(player) + points);
    }

    public void SubtractPoints(int player, int points)
    {
        this.SetCurrentPoints(player, this.GetCurrentPoints(player) - points);
    }
}