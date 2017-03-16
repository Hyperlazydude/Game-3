using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void start()
	{
		SceneManager.LoadSceneAsync("character-select");
	}

	public void exit()
	{
		Application.Quit ();
	}
}
