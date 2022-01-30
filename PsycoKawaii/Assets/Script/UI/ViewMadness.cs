using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMadness : MonoBehaviour
{
    public static ViewMadness Instance;
    private PlayerMediator _playerMediator;

    [SerializeField] private Text _porcent;
    [SerializeField] private Image _fillMadness;

    [SerializeField] private CanvasGroup _viewMadness;
    [SerializeField] private CanvasGroup _endGame;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        UpdateMadness(0);
    }
    private void Start()
    {
        _playerMediator = FindObjectOfType<PlayerMediator>();
    }

    public void UpdateMadness(float porcentMadness)
    {
        var porcent = porcentMadness / 100;
        _fillMadness.fillAmount = porcent;
        _porcent.text = porcentMadness.ToString();
    }

    public void ComprobateGameOver(float porcentMadness)
    {
        if (porcentMadness >= 100)
        {
            LeanTween.alphaCanvas(_endGame, 1,1);
            _playerMediator.SetPause(true);
        }
    }

    public void UpdateMadnessView(float madness)
    {
        var porcentMadness = madness / 100;
        LeanTween.alphaCanvas(_viewMadness, porcentMadness / 2, 0.5f);

    }

}
