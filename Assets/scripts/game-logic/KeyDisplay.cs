using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour {

    private static readonly float PRESSED_ALPHA = 0.5f;
    private static readonly float UNPRESSED_ALPHA = 1;

    public string key;

    public Image keyImage;
    public Text keyText;

    private void Start()
    {
        this.keyText.text = key.ToUpper();
    }

    private void Update()
    {
        if (Input.GetKey(this.key))
        {
            KeyDisplay.SetAlpha(this.keyImage, KeyDisplay.PRESSED_ALPHA);
            KeyDisplay.SetAlpha(this.keyText, KeyDisplay.PRESSED_ALPHA);
        } else
        {
            KeyDisplay.SetAlpha(this.keyImage, KeyDisplay.UNPRESSED_ALPHA);
            KeyDisplay.SetAlpha(this.keyText, KeyDisplay.UNPRESSED_ALPHA);
        }
    }

    private static void SetAlpha(Graphic uiElement, float alpha)
    {
        Color color = uiElement.color;
        color.a = alpha;
        uiElement.color = color;
    }
}
