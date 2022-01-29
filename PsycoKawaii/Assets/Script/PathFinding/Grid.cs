using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private readonly int  _width;
    private readonly int _height;

    private readonly Node _node;
    private readonly Transform _myTransform;
    private readonly LayerMask _wallLayer;
    private Dictionary<Vector2Int, Node> _nodesInGrid;

    public Grid(int width, int height, Node node, Transform myTransform, LayerMask wallLayer)
    {
        _width = width;
        _height = height;
        _node = node;
        _myTransform = myTransform;
        _wallLayer = wallLayer;
        _nodesInGrid = new Dictionary<Vector2Int, Node>();
    }

    public Dictionary<Vector2Int, Node> GetNodeInGrid()
    {
        return _nodesInGrid;
    }

    public void CreateGrid()
    {

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var offsetWidth = x - (_width / 2);
                var offsetHeight = y - (_height / 2);
                var offset = _myTransform.position + _myTransform.right * offsetWidth + _myTransform.up * offsetHeight;

                bool walk = !Physics.CheckSphere(offset, 1, _wallLayer);


                var node = Object.Instantiate(_node, offset, Quaternion.identity, _myTransform);

                var nodePosition = new Vector2Int((int)offset.x, (int)offset.y);

                node.Config(nodePosition, walk);
                node.name = nodePosition.x + " : " + nodePosition.y;

                _nodesInGrid.Add(nodePosition, node);

            }
        }
    }

}
