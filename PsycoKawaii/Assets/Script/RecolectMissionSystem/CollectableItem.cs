using UnityEngine;
using System;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item myitem;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public static event Action<string> EventColletItem;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioCollect;
    private void Awake()
    {
        _spriteRenderer.sprite = myitem.itemImage;
        LeanTween.scale(gameObject, Vector3.one * 0.5f, 1).setEaseInCubic().setLoopPingPong();
    }

    private bool ComprobateMission()
    {
        if (MisionInstaller.Instance.CurrentMision == null)
        {
            return false;
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ComprobateMission())
        {
            return;
        }

        if (!collision.CompareTag("Player"))
        {
            return;
        }

        foreach (var item in MisionInstaller.Instance.CurrentMision.CollectItems)
        {
            if (myitem.id == item.ItemToCollet.id)
            {
                if (!item.IsCollet)
                {
                    item.IsCollet = true;
                    EventColletItem(item.ItemToCollet.id);
                    transform.GetComponent<BoxCollider2D>().enabled = false;

                    LeanTween.cancel(gameObject);
                    LeanTween.scale(gameObject, Vector3.zero * 0.5f, 1).setEaseInCubic();


                    _audioSource.clip = _audioCollect;
                    _audioSource.time = 0.5f;
                    _audioSource.Play();

                    Destroy(gameObject, 2);
                }
            }
        }
    }

}
