using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

	public Dropdown player1;
	public Dropdown player2;
	public Player data;

	public Text text;


	public void startGame() {
		if (player1.options [0].text == "Selete One..." || player2.options [0].text == "Select One...") {
			StartCoroutine (display ());
			return;
		}
		PointSystem.Instance.SetCurrentPoints (data.player1Name, 0);
		PointSystem.Instance.SetCurrentPoints (data.player2Name, 0);
		SceneManager.LoadSceneAsync ("test-level");
	}

	IEnumerator display(){
		text.gameObject.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		text.gameObject.SetActive (false);
	}
}
