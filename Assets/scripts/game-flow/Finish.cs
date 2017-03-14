using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

    private static Finish instance;
    public static Finish Instance
    {
        get { return Finish.instance; }
    }

    public Text finishText;

    private void Awake()
    {
        Finish.instance = this;
    }

    public void ShowFinish(string text)
    {
        this.finishText.text = text;
        this.gameObject.SetActive(true);
    }

    public void HideFinish()
    {
        this.gameObject.SetActive(false);
    }
}
