using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour {

    public HorizontalController player1Control;
    public HorizontalController player2Control;

    private Text fullscreenText;

    private void Awake()
    {
        this.fullscreenText = this.GetComponent<Text>();
    }

    private void Start ()
    {
        this.StartCoroutine(this.Countdown());
	}

    private IEnumerator Countdown()
    {
        this.player1Control.enabled = false;
        this.player2Control.enabled = false;

        for (int i = 3; i > 0; i--)
        {
            this.fullscreenText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        this.fullscreenText.text = "";

        this.player1Control.enabled = true;
        this.player2Control.enabled = true;


    }
}
