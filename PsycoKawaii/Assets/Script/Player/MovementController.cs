using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private readonly Rigidbody2D _rigidbody2D;
    private readonly LevelOfPsychopath _levelOfPsychopath;
    private readonly NpcDetector _npcDetector;
    private readonly int _speed;
    private Vector2 _movement;

    public MovementController(Rigidbody2D rigidbody2D, LevelOfPsychopath levelOfPsychopath,
        NpcDetector npcDetector, int speed)
    {
        _rigidbody2D = rigidbody2D;
        _levelOfPsychopath = levelOfPsychopath;
        _npcDetector = npcDetector;
        _speed = speed;
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
        var movementInput = input * _speed;
        var movementToNpc = inputToNpc * _levelOfPsychopath.GetForceOfMadness();

        _movement = movementInput - movementToNpc;

        _rigidbody2D.velocity = _movement ;
    }

    

}
