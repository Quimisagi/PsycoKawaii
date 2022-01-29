using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMadness : MonoBehaviour
{
    public static ViewMadness Instance;

    [SerializeField] private Text _porcent;
    [SerializeField] private Image _fillMadness;

    [SerializeField] private GameObject _endGame;

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
            _endGame.SetActive(true);
        }
    }

}
