using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
	public void startGame() {
		SceneManager.LoadSceneAsync ("test-level");
	}
}
