using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    private static Dialogue instance;
    public static Dialogue Instance
    {
        get { return Dialogue.instance; }
    }

    public Text speakerName;
    public Text dialogue;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        this.canvasGroup = this.GetComponent<CanvasGroup>();
        Dialogue.instance = this;
    }

    private void Start()
    {
        this.canvasGroup.alpha = 0;
    }

    public void Show(string name, string dialogue)
    {
        this.speakerName.text = name;
        this.dialogue.text = dialogue;

        this.StartCoroutine(this.canvasGroup.FadeAlpha(1, 0.2f));
    }

    public void Hide()
    {
        this.StartCoroutine(this.canvasGroup.FadeAlpha(0, 0.2f));
    }

}
