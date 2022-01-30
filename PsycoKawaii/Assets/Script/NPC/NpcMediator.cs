using UnityEngine;

public class NpcMediator : MonoBehaviour
{
    private NpcMovementController _npcMovementController;
    public LifeController _lifeController { internal set; get; }
    public int Id { get => _id; set => _id = value; }

    private ScaryController _scaryController;

    [Header("Configuracion Movimiento")]
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _speed;

    [Header("Configuracion Esconderse")]
    [SerializeField] private PathFindingInstaller _pathFindingInstaller;
    [SerializeField] private float _radiusFindHidde;
    [SerializeField] private LayerMask _hiddeLayer;

    [SerializeField] private bool test;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private int _id;

    [Header("Configuracion Grito")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Awake()
    {
        _npcMovementController = new NpcMovementController(_rigidbody2D, _speed, transform);
        _lifeController = new LifeController(_rigidbody2D, _spriteRenderer, transform, _audioSource, _audioClip);
        _scaryController = new ScaryController(_pathFindingInstaller, _npcMovementController,
                                                _radiusFindHidde, _hiddeLayer, transform);

    }

    private void Update()
    {
        TryShake();

        if (test)
        {
            TryHiddent();
            test = false;
        }
    }
    private void FixedUpdate()
    {
        TryMove();
    }


    private void TryMove()
    {
       if (_npcMovementController.GetIsMoveCharacter())
        {
            _npcMovementController.DoMovement();
        }
    }

    public void TryHiddent()
    {
        var targetScary = _scaryController.TryFindHiddent();
        if (targetScary != null)
        {
            _scaryController.TryHiddent(targetScary.position);
        }
        else
        {
            _scaryController.Scary = true;
        }

    }

    private void TryShake()
    {
        if (_scaryController.Scary && _lifeController.IsAlive())
        {
            _scaryController.StoppedFear();
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _radiusFindHidde);
    }

}
