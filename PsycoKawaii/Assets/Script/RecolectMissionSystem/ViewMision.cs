using UnityEngine;

public class ViewMision : MonoBehaviour
{
    public GameObject _viewMisionBox;
    public Transform _instance;
    public ItemView _itemView;


    private void Awake()
    {
        _viewMisionBox.SetActive(false);
        _viewMisionBox.transform.localScale = Vector3.zero;
        MisionInstaller._EventMision += ShowMisionBox;

    }

    private void OnDestroy()
    {
        MisionInstaller._EventMision -= ShowMisionBox;

    }

    public void ShowMisionBox(Mision mision)
    {
        _viewMisionBox.SetActive(true);
        LeanTween.scale(_viewMisionBox, Vector3.one, 0.5f).setEaseOutBounce();
        CreateMisionBox(mision);
    }

    public void CreateMisionBox(Mision mision)
    {
        foreach (var item in mision.CollectItems)
        {
            var itemView = Instantiate(_itemView, _instance);
            itemView.SetImage(item.ItemToCollet);
        }
    }

}
