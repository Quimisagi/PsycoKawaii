using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }


    [SerializeField] private Vector2 _limitCameraX;
    [SerializeField] private Vector2 _limitCameraY;
    [SerializeField] private PlayerMediator _playerMediator;
    [SerializeField] private Transform _target;
    [SerializeField] private int _speedCamera;
    public bool IsActive;

    void FixedUpdate()
    {
        if (!IsActive)
        {
            return;
        }
        FollowTarget();
    }

    private void Awake()
    {
        IsActive = true;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        _playerMediator = FindObjectOfType<PlayerMediator>();
        SetTarget(_playerMediator.transform);
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    public void SetLimit(Vector2 limitCameraX, Vector2 limitCameraY)
    {
        _limitCameraX = limitCameraX;
        _limitCameraY = limitCameraY;
    }

    private void FollowTarget()
    {
        var positionTarget = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        var smoothMovement = Vector3.Lerp(transform.position, positionTarget, _speedCamera * Time.deltaTime);

        var newDirection = smoothMovement + Shake();
        newDirection.x = Mathf.Clamp(newDirection.x, _limitCameraX.x, _limitCameraX.y);
        newDirection.y = Mathf.Clamp(newDirection.y, _limitCameraY.x, _limitCameraY.y);


        transform.position = newDirection;


    }

    public Vector3 Shake()
    {
        var shakeForce = _playerMediator._levelOfPsychopath.GetLevelMadness() / 10000;
        //Debug.Log(_playerMediator._levelOfPsychopath.GetLevelMadness());

        float x = Random.Range(-1f, 1f) * shakeForce;
        float z = Random.Range(-1f, 1f) * shakeForce;

        return new Vector3(x, z, 0);
    }

}
