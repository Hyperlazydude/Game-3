using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour {

	public Player player;

	private Dropdown characterSelection;

	// Use this for initialization

	private void Awake() {
		characterSelection = GetComponent<Dropdown> ();
		characterSelection.onValueChanged.AddListener (delegate {deleteSelect();});
	}
	
	public void deleteSelect () {
		if (characterSelection.options [0].text == "Select One...") {
			characterSelection.options.RemoveAt (0);
			characterSelection.value--;
		}
	}

	public void SetPlayer1(int optionSelected) {
		player.player1Char = characterSelection.options [optionSelected].text;
	}

	public void SetPlayer2(int optionSelected) {
		player.player2Char = characterSelection.options [optionSelected].text;
	}
		
}
