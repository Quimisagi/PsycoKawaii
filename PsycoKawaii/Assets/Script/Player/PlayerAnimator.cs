using UnityEngine;

public class PlayerAnimator
{
    private readonly Animator _animator;
    private readonly MovementController _movementController;
    private readonly ParticleSystem _particle;

    public PlayerAnimator(Animator animator, MovementController movementController, ParticleSystem particle)
    {
        _animator = animator;
        _movementController = movementController;
        _particle = particle;
    }

    public void WalkAnim()
    {
        var velocityPlayer = _movementController.DirectionToWalk().magnitude;

        _animator.SetFloat("Speed", velocityPlayer);

        if (velocityPlayer < 0.1f)
        {
            return;
        }

        if (velocityPlayer < 0.5f)
        {
            _animator.speed = velocityPlayer;
        }else
        {
            _animator.speed = 1;

        }


        _particle.Play();
        _animator.SetFloat( "Horizontal", _movementController.DirectionToWalk().x);
        _animator.SetFloat( "Vertical", _movementController.DirectionToWalk().y);
    }

}
