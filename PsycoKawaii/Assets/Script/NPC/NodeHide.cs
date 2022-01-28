using UnityEngine;

public class NodeHide : MonoBehaviour
{
    [SerializeField] private bool _isTake;

    public void Take()
    {
        _isTake = true;
    }
    public bool IsTake()
    {
        return _isTake;
    }
}
