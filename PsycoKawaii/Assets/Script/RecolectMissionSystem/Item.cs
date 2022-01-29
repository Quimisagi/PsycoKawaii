using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Item", menuName = "Mision/Create Item", order = 0)]
public class Item : ScriptableObject
{
    public string id;
    public Sprite itemImage;

}
