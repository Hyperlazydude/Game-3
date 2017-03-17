using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTutorialLogic : LevelFlow {

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
		PointSystem player = PointSystem.Instance;
		int leader = player.CurrentLeader ();
		int second = player.Second ();


		LevelIntro intro = this.intros.First();
		this.StartCoroutine(intro.PlayIntro(
			new Dictionary<string, Transform>
			{
				{"player-1", playerManager.GetPlayer(leader).transform},
				{"player-2", playerManager.GetPlayer(second).transform},
				{"heart", this.transform}
			},
			new Dictionary<string, string>
			{
				{"player-1", playerManager.GetPlayerName(leader)},
				{"player-2", playerManager.GetPlayerName(second)},
				{"heart", "Heart"}
			}
		));
		yield return new WaitForSeconds(intro.Time);

		CameraMovement.Instance.TrackPlayers(0.5f);
		yield return new WaitForSeconds(0.5f);

		Goal.Instance.Show();
		yield return new WaitForSeconds(1.5f);

		Goal.Instance.Hide();

		Finish finish = Finish.Instance;
		finish.ShowFinish("Tutorial Level!!!");
		yield return new WaitForSeconds(2f);
		finish.HideFinish();

		Countdown.Instance.StartCountdown(this.StartLevel);
	}

	private IEnumerator OnTriggerEnter2D(Collider2D collision)
	{
		Player winner = collision.gameObject.GetComponent<Player>();
		if (!this.triggered && winner != null)
		{
			this.triggered = false;

			PlayerManager playerManager = PlayerManager.Instance;
			PointSystem player = PointSystem.Instance;
			int loser = winner.playerNumber == 1 ? 2 : 1;
			Finish finish = Finish.Instance;
			HUD.Hide();
			finish.ShowFinish(PlayerManager.Instance.GetPlayerName(winner.playerNumber) + " won!");

			Player player1 = playerManager.GetPlayer (1);
			Player player2 = playerManager.GetPlayer (2);
			player1.movementEnabled = player1.abilityEnabled = false;
			player2.movementEnabled = player2.abilityEnabled = false;
			yield return new WaitForSeconds(2f);
			finish.HideFinish();

			LevelIntro intro = this.intros[1];
			this.StartCoroutine(intro.PlayIntro(
				new Dictionary<string, Transform>
				{
					{"player-winner", playerManager.GetPlayer(winner.playerNumber).transform},
					{"player-loser", playerManager.GetPlayer(loser).transform},
					{"heart", this.transform}
				},
				new Dictionary<string, string>
				{
					{"player-winner", playerManager.GetPlayerName(winner.playerNumber)},
					{"player-loser", playerManager.GetPlayerName(loser)},
					{"heart", "Heart"}
				}
			));

			yield return new WaitForSeconds(intro.Time);

			CameraMovement.Instance.TrackPlayers(1.5f);
			yield return new WaitForSeconds(2f);

			SwitchScene switchScene = SwitchScene.Instance;

			switchScene.ShuffleLevel();
			SceneManager.LoadSceneAsync(switchScene.GetLevel());
		}
	}
}
