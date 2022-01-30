using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    private string _id;


    private void Awake()
    {
        CollectableItem.EventColletItem += SetHiddent;

    }

    private void OnDestroy()
    {
        CollectableItem.EventColletItem -= SetHiddent;

    }

    public void SetImage(Item newSprite)
    {
        _itemImage.sprite = newSprite.itemImage;
        _id = newSprite.id;
    }

    public void SetHiddent(string id)
    {
        if (_id == id)
        {
            LeanTween.scale(_itemImage.gameObject, Vector3.zero, 1.5f).setEaseInBounce();
            //_itemImage.sprite = null;
            Destroy(gameObject, 2);
        }
    }
}
