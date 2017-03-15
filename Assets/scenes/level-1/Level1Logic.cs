using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Logic : LevelFlow {

    public string nextScene;
    
    private bool triggered;

    protected override void Awake()
    {
        base.Awake();
        this.triggered = false;
    }

    protected override IEnumerator Start()
    {
        yield return base.Start();

        PlayerManager playerManager = PlayerManager.Instance;

        LevelIntro intro = this.intros.First();
        this.StartCoroutine(intro.PlayIntro(
            new Dictionary<string, Transform>
            {
                {"player-1", playerManager.GetPlayer(1).transform},
                {"player-2", playerManager.GetPlayer(2).transform},
                {"heart", this.transform}
            },
            new Dictionary<string, string>
            {
                {"player-1", playerManager.GetPlayerName(1)},
                {"player-2", playerManager.GetPlayerName(2)},
                {"heart", "Heart"}
            }
        ));
        yield return new WaitForSeconds(intro.Time);

        CameraMovement.Instance.TrackPlayers(0.5f);
        yield return new WaitForSeconds(0.5f);

        Goal.Instance.Show();
        yield return new WaitForSeconds(1.5f);

        Goal.Instance.Hide();
        Countdown.Instance.StartCountdown(this.StartLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player winner = collision.gameObject.GetComponent<Player>();
        if (!this.triggered && winner != null)
        {
            this.triggered = false;

            HUD.Hide();
            Finish.Instance.ShowFinish(PlayerManager.Instance.GetPlayerName(winner.playerNumber) + " won!");
            PointSystem.Instance.AddPoints(winner.playerNumber, 50);
            
            this.StartCoroutine(this.GoalHit());
        }
    }

    private IEnumerator GoalHit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(nextScene);
    }
}
