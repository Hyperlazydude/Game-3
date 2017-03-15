using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Logic : LevelFlow {

    public Finish finishController;
    public string nextScene;

    private bool triggered;

    protected override void Awake()
    {
        base.Awake();
        this.triggered = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player winner = collision.gameObject.GetComponent<Player>();
        if (!this.triggered && winner != null)
        {
            this.triggered = false;
            this.finishController.finishText.text = PlayerManager.Instance.GetPlayerName(winner.playerNumber) + " won!";
            PointSystem.Instance.AddPoints(winner.playerNumber, 50);

            this.finishController.gameObject.SetActive(true);
            this.StartCoroutine(this.GoalHit());
        }
    }

    private IEnumerator GoalHit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(nextScene);
    }
}
