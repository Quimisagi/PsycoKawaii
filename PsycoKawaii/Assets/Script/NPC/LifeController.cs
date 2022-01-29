using UnityEngine;

public class LifeController
{
    private readonly Rigidbody2D _rigidbody2D;

    private bool _isAlive;

    public LifeController(Rigidbody2D rigidbody2D)
    {
        _rigidbody2D = rigidbody2D;
        _isAlive = true;
    }


    public bool IsAlive()
    {
        return _isAlive;
    }

    public void Kill()
    {
        _isAlive = false;
        _rigidbody2D.simulated = false;
    }

    



}
