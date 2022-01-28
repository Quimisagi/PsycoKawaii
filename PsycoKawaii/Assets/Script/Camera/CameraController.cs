using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerMediator _playerMediator;
    [SerializeField] private Transform _target;
    [SerializeField] private int _speedCamera;

    void LateUpdate()
    {
        FollowTarget();
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    private void FollowTarget()
    {
        var positionTarget = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        var smoothMovement = Vector3.Lerp(transform.position, positionTarget, _speedCamera * Time.deltaTime); 

        transform.position = smoothMovement + Shake();

    }

    public Vector3 Shake()
    {
        var shakeForce = _playerMediator._levelOfPsychopath.GetLevelMadness() / 10000;
        Debug.Log(_playerMediator._levelOfPsychopath.GetLevelMadness());

        float x = Random.Range(-1f, 1f) * shakeForce;
        float z = Random.Range(-1f, 1f) * shakeForce;

        return new Vector3(x, z, 0);
    }

}
