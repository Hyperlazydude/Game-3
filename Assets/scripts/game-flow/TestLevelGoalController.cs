using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestLevelGoalController : MonoBehaviour {

    public FinishController finishController;
    public string scene;

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
            this.finishController.finishText.text = collision.gameObject.name + " won!";
			PointSystem.Instance.AddPoints (collision.gameObject.name, 50);
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
