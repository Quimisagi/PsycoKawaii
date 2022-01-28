using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector2Int NodePosition;
    public Node NeighborNode;
    public bool IsWalkeable;

    public void Config(Vector2Int nodePosition, bool isWalkeable)
    {
        NodePosition = nodePosition;
        IsWalkeable = isWalkeable;

    }
  
}
