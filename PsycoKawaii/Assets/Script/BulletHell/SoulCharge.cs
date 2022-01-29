using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoulCharge : MonoBehaviour
{
    protected Rigidbody2D _rigidBody;

    public bool IsSoulNear { get; set; }
    public GameObject Soul { get; set; }
    public int Value { get => _value; set => _value = value; }
    protected bool _isActive = true;

    [SerializeField] protected int _value;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!_isActive)
            StopMoving();
        else
        {
            if (IsSoulNear)
            {
                DetermineDirection();

            }
            else
                _rigidBody.velocity = Vector2.zero;
        }
    }

    protected abstract void DetermineDirection();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SendNotification(collision);
        }
    }

    protected abstract void SendNotification(Collider2D collision);

    public void StopMoving()
    {
        IsSoulNear = false;
        Soul = null;
    }
}
