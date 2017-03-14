using UnityEngine;

public class PlayerManager
{
    public enum PlayerType
    {
        JUMPER,
        BOMBER,
        SHOOTER
    }

    
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get { return PlayerManager.instance; }
    }

    public static PlayerManager Instantiate(int numberOfPlayers)
    {
        return PlayerManager.instance = new PlayerManager(numberOfPlayers);
    }

    private int numberOfPlayers;
    public int NumberOfPlayers
    {
        get { return this.numberOfPlayers; }
    }

    private readonly PlayerType[] playerTypes;
    private readonly string[] playerNames;
    private readonly Player[] players;

    private PlayerManager(int numberOfPlayers)
    {
        this.numberOfPlayers = numberOfPlayers;

        this.playerTypes = new PlayerType[this.numberOfPlayers];
        this.playerNames = new string[this.numberOfPlayers];
        this.players = new Player[this.numberOfPlayers];
    }

    public PlayerType GetPlayerType(int player)
    {
        return this.playerTypes[player - 1];
    }

    public void SetPlayerType(int player, PlayerType playerType)
    {
        this.playerTypes[player - 1] = playerType;
    }

    public string GetPlayerName(int player)
    {
        return this.playerNames[player - 1];
    }

    public void SetPlayerName(int player, string name)
    {
        this.playerNames[player - 1] = name;
    }

    public Player GetPlayer(int player)
    {
        return this.players[player - 1];
    }

    public void SpawnPlayers(Vector3[] spawns)
    {
        GameObject prefab;
        GameObject instance;
        Player player;

        for (int playerNumber = 0; playerNumber < this.numberOfPlayers; playerNumber++)
        {
            prefab = PlayerManager.LoadPlayerTypePrefab(this.playerTypes[playerNumber]);
            instance = Object.Instantiate(prefab, spawns[playerNumber], Quaternion.identity);

            player = instance.GetComponent<Player>();
            player.playerNumber = playerNumber + 1;
            this.players[playerNumber] = player;
        }
    }
    
    private static GameObject LoadPlayerTypePrefab(PlayerType playerType)
    {
        string prefabPath;
        switch (playerType)
        {
            case PlayerType.JUMPER:
                prefabPath = "prefabs/DoubleJumpPlayer";
                break;
            case PlayerType.BOMBER:
                prefabPath = "prefabs/BombPlayer";
                break;
            case PlayerType.SHOOTER:
                prefabPath = "prefabs/ShootPlayer";
                break;
            default:
                return null;
        }

        return Resources.Load(prefabPath) as GameObject;
    }

}