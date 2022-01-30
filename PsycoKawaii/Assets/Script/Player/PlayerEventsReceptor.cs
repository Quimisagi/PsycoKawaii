using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventsReceptor : MonoBehaviour
{
    [SerializeField] private PlayerMediator _playerMediator;
    [SerializeField] private GameObject _playerImage;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

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

        _audioSource.clip = _audioClip;
        _audioSource.time = 0.9f;
        _audioSource.Play();
    }

    private IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(1);
        _playerImage.SetActive(true);
        _playerMediator.SetPause(false);
        _playerMediator.ColdwonPause(3);

        var camera = Camera.main.transform;
        camera.GetComponent<CameraController>().IsActive = true;
    }


    private void Desactive()
    {
        _playerImage.SetActive(false);
        _playerMediator.SetPause(true);

        var camera = Camera.main.transform;
        camera.GetComponent<CameraController>().IsActive = false;
        camera.position = new Vector3(0,0,camera.position.z);

    }
}
