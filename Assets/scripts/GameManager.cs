using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Player playerCharacter;
	public GameObject playerPrefab;
	public Camera mainCamera;
	public GameObject countDown;

	[HideInInspector]
	public GameObject player1, player2;

	// Use this for initialization
	private void Awake () {
		//Create Players
		player1 = Instantiate (playerPrefab, new Vector3(-9,2.5f,0), playerPrefab.transform.rotation);
		player2 = Instantiate (playerPrefab, new Vector3(9,2.5f,0), playerPrefab.transform.rotation);

		//Set the player 2 controler
		player2.GetComponent<PlayerManager> ().playerNumber = 2;

		//Set the camera
		CameraMovement movement = mainCamera.GetComponent<CameraMovement> ();
		movement.player1 = player1.transform;
		movement.player2 = player2.transform;

		//Set the players' character
		switch (playerCharacter.player1Name) {
		case "Gunner":
			player1.GetComponent<ShootAbility> ().enabled = true;
			break;
		case "Jumper":
            player1.GetComponent<JumpController>().enabled = false;
			player1.GetComponent<DoubleJumpController> ().enabled = true;
			break;
		case "Bomber":
			player1.GetComponent<BombAbility> ().enabled = true;
			break;
		}
		switch (playerCharacter.player2Name) {
		case "Gunner":
			player2.GetComponent<ShootAbility> ().enabled = true;
			break;
		case "Jumper":
            player2.GetComponent<JumpController>().enabled = false;
            player2.GetComponent<DoubleJumpController> ().enabled = true;
			break;
		case "Bomber":
			player2.GetComponent<BombAbility> ().enabled = true;
			break;
		}

		//Set up the Count Down
		CountdownController counter = countDown.GetComponent<CountdownController>();
		counter.player1Control = player1.GetComponent<HorizontalController> ();
		counter.player2Control = player2.GetComponent<HorizontalController> ();
	}
}
