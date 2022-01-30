using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private PlayerMediator _playerMediator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _backGroundScary;
    private float _redicton;
    private bool _playBackground;

    private void Start()
    {
        _playerMediator = FindObjectOfType<PlayerMediator>();
        _redicton = 1;
    }

    private void Update()
    {
        /*
        if (_playerMediator._levelOfPsychopath.CanAddLevelOfPsychopath())
        {
            _redicton = 1 - (_playerMediator._levelOfPsychopath.GetForceOfMadness() / 10);

            Debug.Log(_playerMediator._levelOfPsychopath.GetForceOfMadness() / 10) ;

            if (_playerMediator._levelOfPsychopath.GetForceOfMadness() > 1.5f && !_playBackground)
            {
                _backGroundScary.Play();
                _playBackground = true;
            }
        }

        _audioSource.pitch = Mathf.Lerp(_audioSource.pitch, _redicton, 1 * Time.deltaTime);
        */
    }


}
