using UnityEngine;

public class PathFindingInstaller : MonoBehaviour
{
    private Grid _grid;
    public PathFindingBFS _pathFindingBFS { internal set; get; }

    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private LayerMask _wallLayer;

    [SerializeField] private Node _node;

    private void Awake()
    {
        _grid = new Grid(_width, _height, _node, transform, _wallLayer);
        _grid.CreateGrid();

        _pathFindingBFS = new PathFindingBFS(_grid.GetNodeInGrid());
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(_width, _height, 0));
    }
}
