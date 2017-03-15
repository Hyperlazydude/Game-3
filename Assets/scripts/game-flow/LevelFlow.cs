using UnityEngine;

public class LevelFlow : MonoBehaviour
{
    public Vector3[] spawns;

    private void Awake()
    {
        PlayerManager.Instance.SpawnPlayers(this.spawns);
    }

    private void Start()
    {
        PlayerManager playerManager = PlayerManager.Instance;

        Player player1 = playerManager.GetPlayer(1);
        Player player2 = playerManager.GetPlayer(2);

        CameraMovement.Instance.SetPlayerTransforms(player1.transform, player2.transform);

        player1.movementEnabled = player1.abilityEnabled = false;
        player2.movementEnabled = player2.abilityEnabled = false;
        
        Countdown.Instance.StartCountdown(this.CountdownOver);
    }

    private void CountdownOver()
    {
        PlayerManager playerManager = PlayerManager.Instance;
        
        Player player1 = playerManager.GetPlayer(1);
        Player player2 = playerManager.GetPlayer(2);

        player1.movementEnabled = player1.abilityEnabled = true;
        player2.movementEnabled = player2.abilityEnabled = true;
    }

}