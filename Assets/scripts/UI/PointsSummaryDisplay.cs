using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PointsSummaryDisplay : MonoBehaviour
{
    public int playerNumber;

    public Text playerName;
    public Text playerPoints;

    public Image jumperImage;
    public Image bomberImage;
    public Image shooterImage;

    public RectTransform playerPointTriangle;

    private int currentPoints;

    private void Start()
    {
        PlayerManager playerManager = PlayerManager.Instance;
        
        switch (playerManager.GetPlayerType(this.playerNumber))
        {
            case PlayerManager.PlayerType.JUMPER:
                this.jumperImage.gameObject.SetActive(true);
                break;
            case PlayerManager.PlayerType.BOMBER:
                this.bomberImage.gameObject.SetActive(true);
                break;
            case PlayerManager.PlayerType.SHOOTER:
                this.shooterImage.gameObject.SetActive(true);
                break;
        }

        this.playerName.text = playerManager.GetPlayerName(this.playerNumber);
        this.SetCurrentPoints(PointSystem.Instance.GetCurrentPoints(this.playerNumber));
    }

    public IEnumerator SetCurrentPoints(int newPoints, float animationTime)
    {
        float started = Time.time;
        int originalPoints = this.currentPoints;

        for (float elapsed = 0; elapsed < animationTime; elapsed = Time.time - started)
        {
            this.SetCurrentPoints(Mathf.RoundToInt(Mathf.SmoothStep(originalPoints, newPoints, elapsed / animationTime)));
            yield return null;
        }

        this.SetCurrentPoints(newPoints);
    }

    private void SetCurrentPoints(int points)
    {
        this.currentPoints = points;
        this.playerPoints.text = points.ToString();

        Vector2 newSize = this.playerPointTriangle.sizeDelta;
        newSize.y = ((float) points / PointSystem.Instance.PointTarget) * 200;
        this.playerPointTriangle.sizeDelta = newSize;
    }

}