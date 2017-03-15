using UnityEngine;

public class Goal : MonoBehaviour {

    private static Goal instance;
    public static Goal Instance
    {
        get { return Goal.instance; }
    }

    private CanvasGroup canvasGroup;

	private void Awake () {
        this.canvasGroup = this.GetComponent<CanvasGroup>();
        Goal.instance = this;
	}

    private void Start()
    {
        this.canvasGroup.alpha = 0;
    }

    public void Show()
    {
        this.StartCoroutine(this.canvasGroup.FadeAlpha(1, 0.2f));
    }

    public void Hide()
    {
        this.StartCoroutine(this.canvasGroup.FadeAlpha(0, 0.2f));
    }
}
