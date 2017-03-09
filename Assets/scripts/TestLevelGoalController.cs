using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestLevelGoalController : MonoBehaviour {

    public Text fullscreenText;

    private bool triggered;

    private void Awake()
    {
        this.triggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.triggered)
        {
            this.triggered = false;
            this.fullscreenText.text = collision.gameObject.name + " won";
            this.StartCoroutine(this.GoalHit());
        }
    }

    private IEnumerator GoalHit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
