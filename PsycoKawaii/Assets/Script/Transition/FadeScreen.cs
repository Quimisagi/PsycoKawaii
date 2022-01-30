using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public CanvasGroup _canvasGroup;
    public void Show(float timeFade)
    {
        LeanTween.alphaCanvas(_canvasGroup, 1, timeFade);
        //_canvasGroup.alpha = 1;
    }

    public void Hidden(float timeFade)
    {
        LeanTween.alphaCanvas(_canvasGroup, 0, timeFade);
        //_canvasGroup.alpha = 0;

    }
}
