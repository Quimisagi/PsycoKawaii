using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private readonly Rigidbody2D _rigidbody2D;
    private readonly LevelOfPsychopath _levelOfPsychopath;
    private readonly NpcDetector _npcDetector;
    private readonly int _speed;
    private readonly float _timeRandomWalk;
    private float _currentTimeRandomWalk;
    private Vector2 _movement;
    private Vector2 _drunkMovement;

    public MovementController(Rigidbody2D rigidbody2D, LevelOfPsychopath levelOfPsychopath,
        NpcDetector npcDetector, int speed , float timeRandomWalk)
    {
        _rigidbody2D = rigidbody2D;
        _levelOfPsychopath = levelOfPsychopath;
        _npcDetector = npcDetector;
        _speed = speed;
        _timeRandomWalk = timeRandomWalk;
    }



    public Vector2 InputKeyBoard()
    {
        var inputHorizontal = Input.GetAxisRaw("Horizontal");
        var inputVertical = Input.GetAxisRaw("Vertical");

        var direction = (Vector2.right * inputHorizontal + Vector2.up * inputVertical).normalized;
        return direction;
    }
    public Vector2 InputToNPC(Transform myTransform)
    {
        if (_npcDetector.GetNpcTarget() == null)
        {
            return Vector2.zero;
        }

        return (myTransform.position - _npcDetector.GetNpcTarget().position).normalized;
    }

    public Vector2 DirectionToWalk()
    {
        return _movement;
    }

    public void DoMove(Vector2 input, Vector2 inputToNpc)
    {
        Drunk();
        var movementInput = input * _speed;
        var movementToNpc = inputToNpc * _levelOfPsychopath.GetForceOfMadness();

        _movement = movementInput - movementToNpc + _drunkMovement;

        _rigidbody2D.velocity = _movement ;
    }

    public void StopMove()
    {
        _rigidbody2D.velocity = Vector2.zero;;
    }


    public void Drunk()
    {

        if (_currentTimeRandomWalk < _timeRandomWalk)
        {
            _currentTimeRandomWalk += Time.deltaTime;
            return;
        }

        var shakeForce = _levelOfPsychopath.GetForceOfMadness() / 5;

        float x = Random.Range(-_speed, _speed) * shakeForce;
        float y = Random.Range(-_speed, _speed) * shakeForce;
        _currentTimeRandomWalk -= _currentTimeRandomWalk;

        _drunkMovement = new Vector2(x, y);
        //Debug.Log(_drunkMovement);

    }
}
