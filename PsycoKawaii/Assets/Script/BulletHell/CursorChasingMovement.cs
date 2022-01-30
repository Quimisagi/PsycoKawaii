using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChasingMovement : MonoBehaviour
{
    private Vector2 _initialPosition, _lastPosition;
    private float _count;
    [SerializeField] private float _speed = 1F;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        currentPosition = Camera.main.ScreenToWorldPoint(currentPosition);
        if (currentPosition != _lastPosition)
        {
            Move();
            ResetDirection(currentPosition);
        }
        else if(_count < 1F)
            Move();
    }

    private void ResetDirection(Vector2 currentPosition)
    {
        _initialPosition = this.transform.position;
        _lastPosition = currentPosition;
        _count = 0f;
    }

    private void Move()
    {
        _count += _speed * Time.deltaTime;
        transform.position = Vector3.Lerp(_initialPosition, _lastPosition, _count);
    }
}
