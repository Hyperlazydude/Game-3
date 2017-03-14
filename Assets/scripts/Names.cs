using System.Collections;
using UnityEngine;

public class Names : MonoBehaviour {

	public Player player;

	public void SetPlayer1Name (string name) {
		if (string.IsNullOrEmpty(name) || name.Trim().Length == 0) {
			name = "Player 1";
		}
		player.player1Name = name;
	}

	public void SetPlayer2Name (string name) {
		if (string.IsNullOrEmpty(name) || name.Trim().Length == 0) {
			name = "Player 2";
		}
		player.player2Name = name;
	}
}
