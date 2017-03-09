using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Player playerCharacter;
	public GameObject playerPrefab;

	public GameObject player1;
	public GameObject player2;

	public Camera mainCamera;


	// Use this for initialization
	private void Awake () {
		player1 = Instantiate (playerPrefab, new Vector3(-9,2.5f,0), playerPrefab.transform.rotation);
		player2 = Instantiate (playerPrefab, new Vector3(9,2.5f,0), playerPrefab.transform.rotation);
		player2.GetComponent<PlayerManager> ().playerNumber = 2;
		CameraMovement movement = mainCamera.GetComponent<CameraMovement> ();
		movement.player1 = player1.transform;
		movement.player2 = player2.transform;


		switch (playerCharacter.player1Name) {
		case "Gunner":
			player1.GetComponent<ShootAbility> ().enabled = true;
			break;
		case "Jumper":
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
			player2.GetComponent<DoubleJumpController> ().enabled = true;
			break;
		case "Bomber":
			player2.GetComponent<BombAbility> ().enabled = true;
			break;
		}
	}
}
