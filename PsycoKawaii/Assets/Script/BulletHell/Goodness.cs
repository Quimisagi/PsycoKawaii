using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodness : SoulCharge
{
    public delegate void GoodnessDelegate();
    public static event GoodnessDelegate notifyDestroyed;

    private void OnDestroy()
    {
        notifyDestroyed = null;
    }

    protected override void DetermineDirection()
    {
        var direction = -(Soul.transform.position - this.transform.position).normalized;
        _rigidBody.velocity = new Vector2(direction.x, direction.y);

    }

    protected override void SendNotification(Collider2D collision)
    {
        notifyDestroyed?.Invoke();
        Destroy(this.gameObject);
        StopMoving();
    }
}
