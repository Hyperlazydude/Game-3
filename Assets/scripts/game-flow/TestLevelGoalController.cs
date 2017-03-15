﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestLevelGoalController : MonoBehaviour {

    public Finish finishController;
    public string scene;

    private bool triggered;

    private void Awake()
    {
        this.triggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player winner = collision.gameObject.GetComponent<Player>();
        if (!this.triggered && winner != null)
        {
            this.triggered = false;
            this.finishController.finishText.text = PlayerManager.Instance.GetPlayerName(winner.playerNumber) + " won!";
			PointSystem.Instance.AddPoints (winner.playerNumber, 50);

            this.finishController.gameObject.SetActive(true);
            this.StartCoroutine(this.GoalHit());
        }
    }

    private IEnumerator GoalHit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(scene);
    }
}
