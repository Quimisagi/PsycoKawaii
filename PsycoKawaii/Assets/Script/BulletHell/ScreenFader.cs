using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        Goodness.notifyDestroyed += FadeInWhite;
        Evilness.notifyGameOver += FadeInRed;
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        Goodness.notifyDestroyed -= FadeInWhite;
        Evilness.notifyGameOver -= FadeInRed;
    }
    public void FadeInWhite()
    {
        GetComponent<Image>().color = new Color(255, 255, 255, 255);
        FadeIn();
    }

    public void FadeInRed()
    {
        GetComponent<Image>().color = new Color(240, 0, 0, 255);
        FadeIn();
    }

    private void FadeIn()
    {
        gameObject.SetActive(true);
        GetComponent<CanvasGroup>().alpha = 0F;
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1F, _speed);
    }

    public void FadeOut(float velocity, float delayTime)
    {
        gameObject.SetActive(true);
        GetComponent<CanvasGroup>().alpha = 1F;
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0F, velocity).setDelay(delayTime);
        LeanTween.delayedCall(gameObject, velocity + delayTime, () => gameObject.SetActive(false));

    }
}
