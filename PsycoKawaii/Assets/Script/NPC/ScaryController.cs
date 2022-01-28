using System.Collections.Generic;
using UnityEngine;

public class ScaryController
{
   private readonly PathFindingInstaller _pathFindingInstaller;
   private readonly NpcMovementController _npcMovementController;
   private readonly float _radiusFindHidde;
   private readonly LayerMask _hiddeLayer;
   private readonly Transform _myTransform;
   public bool Scary { get; set; }

    public ScaryController(PathFindingInstaller pathFindingInstaller,
        NpcMovementController npcMovementController, float radiusFindHidde,
        LayerMask hiddeLayer, Transform myTransform)
    {
        _pathFindingInstaller = pathFindingInstaller;
        _npcMovementController = npcMovementController;
        _radiusFindHidde = radiusFindHidde;
        _hiddeLayer = hiddeLayer;
        _myTransform = myTransform;
    }

    public Transform TryFindHiddent()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_myTransform.position, _radiusFindHidde, _hiddeLayer);

        if (hitColliders.Length <= 0)
        {
            return null;
        }

        foreach (var nodeHide in hitColliders)
        {
            var hideSlot = nodeHide.GetComponent<NodeHide>();

            if (!hideSlot.IsTake())
            {
                hideSlot.Take();
                return hideSlot.transform;
            }
        }

        return null;
    }

    public void TryHiddent(Vector3 targetHiddent)
    {

        var pathFindingBFS = _pathFindingInstaller._pathFindingBFS;

        var endPosition = pathFindingBFS.FindNode(targetHiddent);
        var startPosition = pathFindingBFS.FindNode(_myTransform.position);

        Debug.Log(endPosition.name);
        Debug.Log(startPosition.name);

        var path = pathFindingBFS.FindPath(startPosition, endPosition);
        Debug.Log(pathFindingBFS.FindPath(startPosition, endPosition).Count);
        Debug.Log(path);
        Debug.Log(path.Count);

        _npcMovementController.SetPath(path);
        _npcMovementController.InitWay();
        _npcMovementController.SetMoveCharacter(true);
    }

    public void StoppedFear()
    {
        _myTransform.position = _myTransform.position + Shake();
    }

    public Vector3 Shake()
    {
        var shakeForce = 0.03f;

        float x = Random.Range(-1f, 1f) * shakeForce;
        float z = Random.Range(-1f, 1f) * shakeForce;

        return new Vector3(x, z, 0);
    }


    


}
