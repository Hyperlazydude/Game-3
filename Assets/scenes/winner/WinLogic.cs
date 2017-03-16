using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLogic : LevelFlow {

	public GameObject canvas;

	protected override void Awake()
	{
		canvas.SetActive (false);
		PointSystem player = PointSystem.Instance;
		int leader = player.CurrentLeader ();
		base.spawns = leader == 1 ? new [] {new Vector3 (1, 12, 0), new Vector3 (0, 0, 0)} : new [] {new Vector3(0,0,0), new Vector3(1,12,0)};
		base.Awake();
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
				{"player-winner", playerManager.GetPlayer(leader).transform},
				{"player-loser", playerManager.GetPlayer(second).transform},
				{"heart", this.transform}
			},
			new Dictionary<string, string>
			{
				{"player-winner", playerManager.GetPlayerName(leader)},
				{"player-loser", playerManager.GetPlayerName(second)},
				{"heart", "Heart"}
			}
		));
		yield return new WaitForSeconds(intro.Time);

		CameraMovement.Instance.TrackPlayers(1.5f);
		yield return new WaitForSeconds(1.5f);

		Finish finish = Finish.Instance;
		finish.ShowFinish(PlayerManager.Instance.GetPlayerName(leader) + " won!");
		yield return new WaitForSeconds(2.5f);
		finish.HideFinish();

		canvas.SetActive (true);
	}
}
