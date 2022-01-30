using UnityEngine;

public class AttackController
{
    private readonly NpcDetector _npcDetector;
    private readonly LevelOfPsychopath _levelOfPsychopath;
    private readonly float _radiusToAttack;
    private readonly int _porcentToAttack;
    private readonly Transform _myTransform;
    private float _timeToNextAttack = 0.5f;
    private float _currentTimeToNextAttack;
    private int _levelMadness;

    private readonly float _radiusAlert;
    private readonly LayerMask _npcLayer;

    public AttackController(NpcDetector npcDetector, LevelOfPsychopath levelOfPsychopath,
                        float radiusToAttack, int porcentToAttack, Transform myTransform,
                        float radiusAlert, LayerMask npcLayer)
    {
        _npcDetector = npcDetector;
        _levelOfPsychopath = levelOfPsychopath;
        _radiusToAttack = radiusToAttack;
        _porcentToAttack = porcentToAttack;
        _myTransform = myTransform;
        _radiusAlert = radiusAlert;
        _npcLayer = npcLayer;
    }

    public bool TryAttack()
    {
        if (_npcDetector.GetNpcTarget() == null)
        {
            return false;
        }

      

        if (_levelOfPsychopath.GetLevelMadness() <= _porcentToAttack)
        {
            return false;
        }

        if (_currentTimeToNextAttack < _timeToNextAttack)
        {
            _currentTimeToNextAttack += Time.deltaTime;
            return false;
        }

        var distance = (_myTransform.position - _npcDetector.GetNpcTarget().position).magnitude;
        if (distance < _radiusToAttack)
        {
            return true;
        }

        return false;
    }

    public void DoAttack()
    {
        _currentTimeToNextAttack -= _currentTimeToNextAttack;
        _levelOfPsychopath.AddLevelPsychopath(5);
        _levelMadness += 35;

        ViewMadness.Instance.UpdateMadness(_levelMadness);
        ViewMadness.Instance.ComprobateGameOver(_levelMadness);

        //_playerMediator.SetPause(true);
        var npc = _npcDetector.GetNpcTarget().GetComponent<NpcMediator>();
        npc._lifeController.Kill();

        AlertNeighbors();
        Debug.Log("Activar Evento Combate");
    }


    private void AlertNeighbors()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_myTransform.position, _radiusAlert * 3, _npcLayer);

        if (hitColliders.Length <= 0)
        {
            return;
        }

        foreach (var npc in hitColliders)
        {
            var npcAlert = npc.GetComponent<NpcMediator>();

            if (npcAlert._lifeController.IsAlive())
            {
                npcAlert.TryHiddent();
            }
        }

    }

}
