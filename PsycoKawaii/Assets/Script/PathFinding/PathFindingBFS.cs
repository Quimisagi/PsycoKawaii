using System.Collections.Generic;
using UnityEngine;

public class PathFindingBFS
{
    public Dictionary<Vector2Int, Node> _nodes;

    public PathFindingBFS(Dictionary<Vector2Int, Node> nodes)
    {
        _nodes = nodes;
    }

    public Node FindNode(Vector2 initPosition)
    {
        var nodePosX = Mathf.RoundToInt(initPosition.x);
        var nodePosY = Mathf.RoundToInt(initPosition.y);
        var nodePosition = new Vector2Int(nodePosX, nodePosY);

        if (!_nodes.ContainsKey(nodePosition))
        {
            return null;
        }

        return _nodes[nodePosition];
    }


    public List<Node> FindPath(Node startNode, Node endNode)
    {
        HashSet<Node> nodesExplored = new HashSet<Node>();
        Queue<Node> positionInGrid = new Queue<Node>();

        positionInGrid.Enqueue(startNode);

        if (startNode == endNode || endNode.IsWalkeable == false)
        {
            return null;
        }

        while (positionInGrid.Count > 0)
        {

            var inicialNode = positionInGrid.Dequeue();
            var Neighbours = FindNeighbours(inicialNode);

            foreach (var Neighbor in Neighbours)
            {
                if (!nodesExplored.Contains(Neighbor) && !positionInGrid.Contains(Neighbor))
                {
                    positionInGrid.Enqueue(Neighbor);
                    Neighbor.NeighborNode = inicialNode;

                    if (Neighbor == endNode)
                    {
                        return BuildPath(startNode, endNode);
                    }
                }
            }

            nodesExplored.Add(inicialNode);

        }

        Debug.Log("No se logro encontrar el camino");
        return null;
    }

    private List<Node> FindNeighbours(Node nodeStart)
    {
        Vector2Int[] validMovement = { Vector2Int.up, Vector2Int.right,
                                        Vector2Int.down, Vector2Int.left };

        var neighboursNodes = new List<Node>();

        foreach (var position in validMovement)
        {

            var positionNeighbours = nodeStart.NodePosition + position;

            if (!_nodes.ContainsKey(positionNeighbours))
            {
                continue;
            }

            if (!_nodes[positionNeighbours].IsWalkeable)
            {
                continue;
            }

            neighboursNodes.Add(_nodes[positionNeighbours]);

        }

        return neighboursNodes;

    }

    private List<Node> BuildPath(Node startNode, Node endNode)
    {
        List<Node> Path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            Path.Add(currentNode);
            currentNode = currentNode.NeighborNode;

        }

        Path.Reverse();
        return Path;
    }

}
