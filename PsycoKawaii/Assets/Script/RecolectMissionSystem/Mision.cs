using UnityEngine;

[CreateAssetMenu(fileName = "Mision", menuName = "Mision/Create Mision", order = 1)]
public class Mision : ScriptableObject
{
    public ColletItem[] CollectItems;
    public bool MisionComplete;
}

[System.Serializable]
public class ColletItem
{
    public Item ItemToCollet;
    public bool IsCollet;
}