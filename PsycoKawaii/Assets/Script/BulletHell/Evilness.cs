﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evilness : SoulCharge
{
    public delegate void EvilnessDelegate();
    public static event EvilnessDelegate notifyGameOver;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        Goodness.notifyDestroyed += Finish;
        Timer.notifyTimeRanOut += Finish;
        GameActivator.startGame += () => _isActive = true;

    }

    private void OnDestroy()
    {
        notifyGameOver = null;
        Goodness.notifyDestroyed -= Finish;
        Timer.notifyTimeRanOut -= Finish;
        GameActivator.startGame -= () => _isActive = true;
    }

    protected override void DetermineDirection()
    {
        var direction = (Soul.transform.position - this.transform.position).normalized;
        _rigidBody.velocity = new Vector2(direction.x, direction.y) * GetVelocity();

    }

    private float GetVelocity()
    {
        switch (_value)
        {
            case 1:
                return 3F;
                break;
            case 2:
                return 1.5F;
                break;
            case 3:
                return 0.5F;
                break;
        }
        return 1F;
    }

    private void Finish()
    {
        _isActive   = false;
        Destroy(this.gameObject);
    }

    protected override void SendNotification(Collider2D collision)
    {
        notifyGameOver?.Invoke();
        Destroy(collision.gameObject);
        StopMoving();
    }
}
