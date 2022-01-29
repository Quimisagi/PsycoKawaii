using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evilness : MonoBehaviour
{
    public delegate void EvilnessDelegate();
    public static event EvilnessDelegate notifyGameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            notifyGameOver?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        notifyGameOver = null;
    }
}
