using UnityEngine;
using UnityEngine.UI;

public class PointsSummary : MonoBehaviour {

    private static PointsSummary instance;
    public static PointsSummary Instance
    {
        get { return PointsSummary.instance; }
    }

    public Text pointTarget;
    public PointsSummaryDisplay[] displays;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        this.canvasGroup = this.GetComponent<CanvasGroup>();
        PointsSummary.instance = this;
    }

    private void Start()
    {
        this.pointTarget.text = PointSystem.Instance.PointTarget.ToString();
        this.canvasGroup.alpha = 0;
    }

    public void SetCurrentPoints(int player, int points, float animationTime)
    {
        this.StartCoroutine(this.displays[player - 1].SetCurrentPoints(points, animationTime));
    }

    public void Show()
    {
        this.StartCoroutine(this.canvasGroup.FadeAlpha(1, 0.2f));
    }

    public void Hide()
    {
        this.StartCoroutine(this.canvasGroup.FadeAlpha(1, 0.2f));
    }

}
