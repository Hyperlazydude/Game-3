using UnityEngine;

public class PlayerManager
{
    public enum PlayerType
    {
        JUMPER,
        BOMBER,
        SHOOTER
    }

    private static readonly PlayerManager instance = new PlayerManager();
    public static PlayerManager Instance
    {
        get { return PlayerManager.instance; }
    }

    private PlayerType player1Type;
    private PlayerType player2Type;

    private Player player1;
    public Player Player1
    {
        get { return this.player1; }
    }

    private Player player2;
    public Player Player2
    {
        get { return this.player2; }
    }

    private PlayerManager()
    {
        this.player1Type = 0;
        this.player2Type = 0;
    }
    
    public void InstantiatePlayers(Vector3 player1Spawn, Vector3 player2Spawn)
    {
        GameObject player1Prefab = PlayerManager.LoadPlayerPrefab(this.player1Type);
        GameObject player1Object = Object.Instantiate(player1Prefab, player1Spawn, Quaternion.identity);
        this.player1 = player1Object.GetComponent<Player>();

        GameObject player2Prefab = PlayerManager.LoadPlayerPrefab(this.player2Type);
        GameObject player2Object = Object.Instantiate(player2Prefab, player2Spawn, Quaternion.identity);
        this.player2 = player2Object.GetComponent<Player>();
    }

    private static GameObject LoadPlayerPrefab(PlayerType playerType)
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