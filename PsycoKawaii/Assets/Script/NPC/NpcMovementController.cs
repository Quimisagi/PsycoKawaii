using System.Collections.Generic;
using UnityEngine;

public class NpcMovementController
{
    private readonly CharacterController _characterController;
    private readonly int _speed;
    private readonly Transform _myTransform;

    private int _currentIndex;
    private Vector3 _actualPosition;
    private List<Node> _path = new List<Node>();
    private bool _isMove;

    public NpcMovementController(CharacterController characterController, int speed, Transform myTransform)
    {
        _characterController = characterController;
        _speed = speed;
        _myTransform = myTransform;
    }



    public void SetMoveCharacter(bool isMove)
    {
        _isMove = isMove;
    }

    public bool GetIsMoveCharacter()
    {
        return _isMove;
    }

    public void InitWay()
    {
        _currentIndex = 0;
        _actualPosition = _path[_currentIndex].transform.position;

    }

    public void SetPath(List<Node> path)
    {
        _path = path;
    }

   
    public void DoMovement()
    {
        if (Vector3.Distance(_myTransform.position, _actualPosition) < 0.1f)
        {

            if (_currentIndex >= _path.Count - 1)
            {
                Debug.Log("Termino Recorrido");
                _isMove = false;
                return;
            }

            _currentIndex++;
            _actualPosition = _path[_currentIndex].transform.position;

        }

        var directionInput = (_actualPosition - _myTransform.position).normalized;

        Debug.Log(directionInput);
        _characterController.Move(directionInput * (_speed * Time.deltaTime));
    }
}
