using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventsReceptor : MonoBehaviour
{
    void Start()
    {
        AttackController.startAtack += Desactive;
        Goodness.notifyDestroyed += Forgive;
        Evilness.notifyGameOver += Kill;
        Timer.notifyTimeRanOut += Kill;
    }

    private void OnDestroy()
    {
        AttackController.startAtack -= Desactive;
        Goodness.notifyDestroyed -= Forgive;
        Evilness.notifyGameOver -= Kill;
        Timer.notifyTimeRanOut -= Kill;
    }

    private void Desactive()
    {
        this.gameObject.SetActive(false);
    }

    private void Forgive()
    {
        Reactivate();
        var player = GetComponent<PlayerMediator>();
        player.AttackController.Forgive();
    }

    private void Kill()
    {
        Reactivate();
        var player = GetComponent<PlayerMediator>();
        player.AttackController.Murder();
    }

    private void Reactivate()
    {
        this.gameObject.SetActive(true);
    }
}
