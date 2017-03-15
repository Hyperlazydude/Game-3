using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    private static Countdown instance;
    public static Countdown Instance
    {
        get { return Countdown.instance; }
    }

    public Text countdownText;

    private void Awake()
    {
        Countdown.instance = this;
        this.gameObject.SetActive(false);
    }

    public void StartCountdown(System.Action callback)
    {
        this.gameObject.SetActive(true);
        this.StartCoroutine(this.DoCountdown(callback));
    }

    private IEnumerator DoCountdown(System.Action callback)
    {
        for (int i = 3; i > 0; i--)
        {
            this.countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        this.countdownText.text = "";
        this.gameObject.SetActive(false);

        if (callback != null)
            callback.Invoke();
    }
}
