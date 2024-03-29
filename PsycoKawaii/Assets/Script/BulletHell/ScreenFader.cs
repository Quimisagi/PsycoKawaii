﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        Goodness.notifyDestroyed += FadeInWhite;
        Evilness.notifyGameOver += FadeInRed;
        Timer.notifyTimeRanOut += FadeInRed;
        AttackController.startAtack += FadeInWhite;
        FadeOut();
    }
    private void OnDestroy()
    {
        Goodness.notifyDestroyed -= FadeInWhite;
        Evilness.notifyGameOver -= FadeInRed;
        Timer.notifyTimeRanOut -= FadeInRed;
        AttackController.startAtack -= FadeInWhite;
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
        LeanTween.delayedCall(this.gameObject, 1F, () => SceneManager.LoadScene("SampleScene"));
    }

    public void FadeOut()
    {
        gameObject.SetActive(true);
        GetComponent<CanvasGroup>().alpha = 1F;
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0F, 1F);
        LeanTween.delayedCall(gameObject, 1F, () => gameObject.SetActive(false));

    }
}
