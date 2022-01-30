using UnityEngine;

public class LifeController
{
    private readonly Rigidbody2D _rigidbody2D;
    private readonly SpriteRenderer _spriteRenderer;
    private readonly Transform _npc;
    private readonly AudioSource _audioSource;
    private readonly AudioClip _audioClip;

    private bool _isAlive;

    public LifeController(Rigidbody2D rigidbody2D, SpriteRenderer spriteRenderer, Transform npc, AudioSource audioSource, AudioClip audioClip)
    {
        _rigidbody2D = rigidbody2D;
        _spriteRenderer = spriteRenderer;
        _npc = npc;
        _audioSource = audioSource;
        _audioClip = audioClip;
        _isAlive = true;
    }


    public bool IsAlive()
    {
        return _isAlive;
    }

    public void AddIdToListAndKill()
    {
        int id = _npc.gameObject.GetComponent<NpcMediator>().Id;
        StateOfNPCs.Instance.DeadNPCs.Add(id);
        Kill();
    }

    public void Kill()
    {
        _isAlive = false;
        _spriteRenderer.color = Color.red;
        _npc.rotation = Quaternion.Euler(new Vector3(0, 0, 55));
        _rigidbody2D.simulated = false;

        _audioSource.clip = _audioClip;
        _audioSource.time = 0.2f;

        _audioSource.Play();
    }

    



}
