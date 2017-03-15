using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Logic : LevelFlow {
    
    public string nextScene;

    private bool triggered;

    protected override void Awake()
    {
        base.Awake();
        this.triggered = false;
    }

    protected override void Start()
    {
        base.Start();
        this.StartCoroutine(this.LevelIntro());
    }

    private IEnumerator LevelIntro()
    {
        CameraMovement camera = CameraMovement.Instance;
        PlayerManager playerManager = PlayerManager.Instance;
        Dialogue dialogue = Dialogue.Instance;

        string player1Name = playerManager.GetPlayerName(1);
        string player2Name = playerManager.GetPlayerName(2);

        Vector3 player1Position = playerManager.GetPlayer(1).transform.position;
        Vector3 player2Position = playerManager.GetPlayer(2).transform.position;

        camera.MoveToPoint(this.transform.position, 0);
        dialogue.Show("Heart", "Ohhhh, I'm so high up! How will I ever get down?");
        yield return new WaitForSeconds(1.5f);

        dialogue.Hide();
        camera.MoveToPoint(player1Position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        dialogue.Show(player1Name, "It's not that high of a drop, ma'am.");
        yield return new WaitForSeconds(1.5f);

        dialogue.Hide();
        camera.MoveToPoint(player2Position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        dialogue.Show(player2Name, "The princess shall not sully her hands! If you won't save her, I will!");
        yield return new WaitForSeconds(1.5f);

        dialogue.Hide();
        camera.MoveToPoint(player1Position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        dialogue.Show(player1Name, "Go ahead, knock yourself out.");
        yield return new WaitForSeconds(1.5f);

        dialogue.Hide();
        camera.TrackPlayers(0.5f);
        yield return new WaitForSeconds(0.5f);

        Goal.Instance.Show();
        yield return new WaitForSeconds(1.5f);

        Goal.Instance.Hide();
        Countdown.Instance.StartCountdown(this.StartLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player winner = collision.gameObject.GetComponent<Player>();
        if (!this.triggered && winner != null)
        {
            this.triggered = false;

            HUD.Hide();
            Finish.Instance.ShowFinish(PlayerManager.Instance.GetPlayerName(winner.playerNumber) + " won!");
            PointSystem.Instance.AddPoints(winner.playerNumber, 50);
            
            this.StartCoroutine(this.GoalHit());
        }
    }

    private IEnumerator GoalHit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(nextScene);
    }
}
