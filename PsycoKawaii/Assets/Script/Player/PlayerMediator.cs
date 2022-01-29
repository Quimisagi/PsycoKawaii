﻿using UnityEngine;

public class PlayerMediator : MonoBehaviour
{

    private MovementController _movementController;
    private NpcDetector _npcDetector;
    private AttackController _attackController;
    public LevelOfPsychopath _levelOfPsychopath { internal set; get; }

    [Header("Configuracion Movimiento")]
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _speed;

    [Header("Configuracion DeteccionNpc")]
    [SerializeField] private int _radiusDetection;
    [SerializeField] private LayerMask _layerDetection;

    [Header("Configuracion Porcentaje Locura")]
    [SerializeField] private int _nextTimeToAdd;
    [SerializeField] private float _madnessPerSecond;

    [Header("Configuracion Ataque")]
    [SerializeField] private float _radiusToAttack;
    [SerializeField] private int _porcentToAttack;
    [SerializeField] private float _radiusAlert;

    [SerializeField] private bool _pause;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _npcDetector = new NpcDetector(_radiusDetection, _layerDetection, transform);
        _levelOfPsychopath = new LevelOfPsychopath(_nextTimeToAdd, _speed, _madnessPerSecond);
        _attackController = new AttackController( _npcDetector, _levelOfPsychopath, _radiusToAttack,
                           _porcentToAttack, transform, _radiusAlert, _layerDetection);

        _movementController = new MovementController(_rigidbody2D, _levelOfPsychopath, _npcDetector, _speed);
    }

    void Update()
    {

        if (_pause)
        {
            return;
        }
        TryAttack();
        _levelOfPsychopath.PsychopathController();
        _npcDetector.DetectorNpc();
    }

    private void FixedUpdate()
    {
        if (_pause)
        {
            _movementController.DoMove(Vector2.zero, Vector2.zero);
            return;
        }

        PlayerMovement();

    }

    private void PlayerMovement()
    {
        var input = _movementController.InputKeyBoard();
        var npcInput = _movementController.InputToNPC(transform);
        _movementController.DoMove(input, npcInput);
    }

    private void TryAttack()
    {
        if (_attackController.TryAttack())
        {
            Debug.Log("Atacar");
            _attackController.DoAttack();
        }
    }

    public void SetPause(bool pause)
    {
        _pause = pause;
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _radiusDetection);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusToAttack);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _radiusAlert);
    }
}