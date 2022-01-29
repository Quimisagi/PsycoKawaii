using UnityEngine;
using System;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item myitem;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public static event Action<string> EventColletItem;

    private void Awake()
    {
        _spriteRenderer.sprite = myitem.itemImage;
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
                    Destroy(gameObject);
                }
            }
        }
    }

}
