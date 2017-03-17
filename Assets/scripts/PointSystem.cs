using UnityEngine;

public class PointSystem
{
    private static PointSystem instance;
    public static PointSystem Instance
    {
        get { return PointSystem.instance; }
    }

    public static PointSystem Instantiate(int numPlayers, int pointLimit)
    {
        return PointSystem.instance = new PointSystem(numPlayers, pointLimit);
    }

    private readonly int[] points;
    public int[] Points
    {
        get { return this.points; }
    }

    private readonly int pointLimit;
    public int PointTarget
    {
        get { return this.pointLimit; }
    }

    private PointSystem(int numberOfPlayers, int pointLimit)
    {
        this.points = new int[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
            this.points[i] = 0;

        this.pointLimit = pointLimit;
    }

    public int GetCurrentPoints(int player)
    {
        return this.points[player - 1];
    }

    public int SetCurrentPoints(int player, int points)
    {
		return this.points[player - 1] = Mathf.Clamp(points, 0, this.pointLimit);
    }

    public int AddPoints(int player, int points)
    {
        return this.SetCurrentPoints(player, this.GetCurrentPoints(player) + points);
    }

    public int SubtractPoints(int player, int points)
    {
        return this.SetCurrentPoints(player, this.GetCurrentPoints(player) - points);
    }

	public int CurrentLeader()
	{
		return GetCurrentPoints (1) >= GetCurrentPoints (2) ? 1 : 2;
	}

	public int Second()
	{
		return this.GetCurrentPoints (1) >= GetCurrentPoints (2) ? 2 : 1;
	}
}