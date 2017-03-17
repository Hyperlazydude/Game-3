using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Logic : LevelFlow {

    public Transform deadliftPosition;
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
                {"deadlift", this.deadliftPosition}
            },
            new Dictionary<string, string>
            {
                {"player-1", playerManager.GetPlayerName(1)},
                {"player-2", playerManager.GetPlayerName(2)},
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

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        Player winner = collision.gameObject.GetComponent<Player>();
        if (!this.triggered && winner != null)
        {
            this.triggered = false;
			this.gameObject.GetComponent<Collider2D> ().enabled = false;

            Finish finish = Finish.Instance;
            HUD.Hide();
            finish.ShowFinish(PlayerManager.Instance.GetPlayerName(winner.playerNumber) + " won!");
            yield return new WaitForSeconds(2f);
            finish.HideFinish();

//			int points = 75;
//			if (PointSystem.Instance.CurrentLeader() == winner.playerNumber 
//				&& PointSystem.Instance.GetCurrentPoints(winner.playerNumber) == 150)
//				points = 50;

            PointsSummary pointsSummary = PointsSummary.Instance;
			int newPoints = PointSystem.Instance.AddPoints(winner.playerNumber, 75);
            pointsSummary.Show();
            pointsSummary.SetCurrentPoints(winner.playerNumber, newPoints, 2f);
            yield return new WaitForSeconds(2f);
            pointsSummary.Hide();

            yield return new WaitForSeconds(2f);
			if (PointSystem.Instance.GetCurrentPoints (PointSystem.Instance.CurrentLeader ()) >= 200) {
				SceneManager.LoadSceneAsync ("winning-scene");
			} else {
				SceneManager.LoadSceneAsync(SwitchScene.Instance.GetLevel());
			}
        }
    }
}
