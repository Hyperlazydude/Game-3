using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public Player player;

	private Dropdown characterSelection;

	// Use this for initialization

	private void Awake() {
		characterSelection = GetComponent<Dropdown> ();
	}

	public void SetPlayer1(int optionSelected) {
		player.player1Name = characterSelection.options [optionSelected].text;
	}

	public void SetPlayer2(int optionSelected) {
		player.player2Name = characterSelection.options [optionSelected].text;
	}
}
