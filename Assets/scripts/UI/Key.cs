using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

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
            Key.SetAlpha(this.keyImage, Key.PRESSED_ALPHA);
            Key.SetAlpha(this.keyText, Key.PRESSED_ALPHA);
        } else
        {
            Key.SetAlpha(this.keyImage, Key.UNPRESSED_ALPHA);
            Key.SetAlpha(this.keyText, Key.UNPRESSED_ALPHA);
        }
    }

    private static void SetAlpha(Graphic uiElement, float alpha)
    {
        Color color = uiElement.color;
        color.a = alpha;
        uiElement.color = color;
    }
}
