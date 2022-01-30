using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodness : SoulCharge
{
    public delegate void GoodnessDelegate();
    public static event GoodnessDelegate notifyDestroyed;

    [SerializeField] private ParticleSystem _particles;



    private void OnDestroy()
    {
        //notifyDestroyed = null;
    }

    protected override void DetermineDirection()
    {
        if (Soul == null)
        {
            return;
        }
        var direction = -(Soul.transform.position - this.transform.position).normalized;
        _rigidBody.velocity = new Vector2(direction.x, direction.y);

    }

    protected override void SendNotification(Collider2D collision)
    {
        notifyDestroyed?.Invoke();
        //this.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255, 0);
        _audioSource.Play();
        _particles.Play();
        StopMoving();
    }
}
