using UnityEngine;

public class NpcDetector
{
    private readonly int _radiusDetection;
    private readonly LayerMask _layerDetection;
    private readonly Transform _myTransform;
    private Transform _npcTarget;

    public NpcDetector(int radiusDetection, LayerMask layerDetection, Transform myTransform)
    {
        _radiusDetection = radiusDetection;
        _layerDetection = layerDetection;
        _myTransform = myTransform;
    }

    public Transform GetNpcTarget()
    {
        return _npcTarget;
    }

    public void DetectorNpc()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_myTransform.position, _radiusDetection, _layerDetection);
    
        if (hitColliders.Length < 1)
        {
            _npcTarget = null;
            return;
        }

        _npcTarget = GetClosestNpc(hitColliders);

        if (_npcTarget != null)
        {
            //Debug.Log(_npcTarget.name);
            Debug.DrawLine(_myTransform.position, _npcTarget.position);
        }
        
    }

    private Transform GetClosestNpc(Collider2D[] Npc)
    {
        float closeDistance = _radiusDetection * 4;
        Transform npcTarget = null;

        foreach (var hitCollider in Npc)
        {
            var distance = hitCollider.transform.position - _myTransform.position;
            var distenceToTarget = distance.sqrMagnitude;

            if (distenceToTarget < closeDistance)
            {
                closeDistance = distenceToTarget;
                npcTarget = hitCollider.transform;
            }
        }
        
        return npcTarget;
    }


    

}
