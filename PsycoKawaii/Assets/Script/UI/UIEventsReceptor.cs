using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventsReceptor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AttackController.startAtack += Desactive;
        Goodness.notifyDestroyed += Reactivate;
        Evilness.notifyGameOver += Reactivate;
        Timer.notifyTimeRanOut += Reactivate;
    }

    private void OnDestroy()
    {
        AttackController.startAtack -= Desactive;
        Goodness.notifyDestroyed -= Reactivate;
        Evilness.notifyGameOver -= Reactivate;
        Timer.notifyTimeRanOut -= Reactivate;
    }

    private void Desactive()
    {
        this.gameObject.SetActive(false);
    }

    private void Reactivate()
    {
        this.gameObject.SetActive(true);

    }
}
