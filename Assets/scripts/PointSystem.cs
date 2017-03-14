using System.Collections.Generic;
using System.Linq;

public class PointSystem
{
    private static readonly PointSystem instance = new PointSystem();
    public static PointSystem Instance
    {
        get { return PointSystem.instance; }
    }

    private Dictionary<string, int> points;
    public Dictionary<string, int> Points
    {
        get { return this.points; }
    }

    private PointSystem()
    {
        this.points = new Dictionary<string, int>();
    }

    public int GetCurrentPoints(string player)
    {
        int currentPoints;
        if (this.points.TryGetValue(player, out currentPoints))
            return currentPoints;
        return 0;
    }

    public void SetCurrentPoints(string player, int points)
    {
        this.points[player] = points;
    }

    public void AddPoints(string player, int points)
    {
        this.SetCurrentPoints(player, this.GetCurrentPoints(player) + points);
    }

    public void SubtractPoints(string player, int points)
    {
        this.SetCurrentPoints(player, this.GetCurrentPoints(player) - points);
    }

    public string CurrentLeader()
    {
        if (this.points.Count == 0)
            return "";
        return this.points.Aggregate(this.points.First(), (currentLeader, next) => currentLeader.Value > next.Value ? currentLeader : next).Key;
    }
}