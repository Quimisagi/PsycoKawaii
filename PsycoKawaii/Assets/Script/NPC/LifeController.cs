using UnityEngine;

public class LifeController
{
    private readonly CharacterController _characterController;

    private bool _isAlive;

    public LifeController(CharacterController characterController)
    {
        _characterController = characterController;
        _isAlive = true;
    }


    public bool IsAlive()
    {
        return _isAlive;
    }

    public void Kill()
    {
        _isAlive = false;
        _characterController.enabled = false;
    }

    



}
