using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prueba : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Goodness.notifyDestroyed += cogioGoodness;
        Evilness.notifyGameOver += cogioBadness;
        Timer.notifyTimeRanOut += cogioBadness;
    }

    private void cogioGoodness()
    {
        text.text = "No mates XD";
    }

    private void cogioBadness()
    {
        text.text = "Oh no :(";
    }
}
