using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public CanvasGroup _canvasGroup;
    public void Show(float timeFade)
    {
        _canvasGroup.alpha = 1;

    }

    public void Hidden(float timeFade)
    {
        _canvasGroup.alpha = 0;

    }
}
