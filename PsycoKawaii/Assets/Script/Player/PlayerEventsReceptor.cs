using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventsReceptor : MonoBehaviour
{
    [SerializeField] private PlayerMediator _playerMediator;
    [SerializeField] private GameObject _playerImage;

    void Start()
    {
        AttackController.startAtack += Desactive;
        Goodness.notifyDestroyed += Forgive;
        Evilness.notifyGameOver += Kill;
        Timer.notifyTimeRanOut += Kill;
    }

    private void OnDisable()
    {
        AttackController.startAtack -= Desactive;
        Goodness.notifyDestroyed -= Forgive;
        Evilness.notifyGameOver -= Kill;
        Timer.notifyTimeRanOut -= Kill;
    }

    

    private void Forgive()
    {
        StartCoroutine(Reactivate());
        _playerMediator.AttackController.Forgive();
    }

    private void Kill()
    {
        StartCoroutine(Reactivate());
        _playerMediator.AttackController.Murder();
    }

    private IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(1);
        _playerImage.SetActive(true);
        _playerMediator.SetPause(false);
    }


    private void Desactive()
    {
        _playerImage.SetActive(false);
        _playerMediator.SetPause(true);

    }
}
