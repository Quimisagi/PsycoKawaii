using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMadness : MonoBehaviour
{
    [SerializeField] private Text _porcent;
    [SerializeField] private Image _fillMadness;


    private void UpdateMadness(float porcentMadness)
    {
        var porcent = porcentMadness / 100;
        _fillMadness.fillAmount = porcent;
        _porcent.text = porcent.ToString();
    }
}
