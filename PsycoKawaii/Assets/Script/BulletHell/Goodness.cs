using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodness : MonoBehaviour
{
    public delegate void GoodnessDelegate();
    public static event GoodnessDelegate notifyDestroyed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            notifyDestroyed?.Invoke();
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        notifyDestroyed = null;
    }
}
