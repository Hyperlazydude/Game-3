using System.Collections;
using UnityEngine;

public static class Extensions
{
    public static IEnumerator FadeAlpha(this CanvasGroup canvasGroup, float newAlpha, float time)
    {
        float initial = canvasGroup.alpha;
        float start = Time.time;

        for (float elapsedTime = 0; elapsedTime <= time; elapsedTime = Time.time - start)
        {
            canvasGroup.alpha = Mathf.SmoothStep(initial, newAlpha, elapsedTime / time);
            yield return null;
        }

        canvasGroup.alpha = newAlpha;
    }
}
