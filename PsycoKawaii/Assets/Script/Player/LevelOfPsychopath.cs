using UnityEngine;

public class LevelOfPsychopath
{
    private readonly int _nextTimeToAdd;
    private float _currentTimeToAdd;

    private float _currentLevelMadness;
    private readonly float  _madnessPerSecond;
    public float _forceOfMadness;

    private int _speedPlayer;

    public LevelOfPsychopath(int nextTimeToAdd, int speedPlayer, float madnessPerSecond)
    {
        _nextTimeToAdd = nextTimeToAdd;
        _speedPlayer = speedPlayer + 1;
        _madnessPerSecond = madnessPerSecond;
    }

    public float GetForceOfMadness()
    {
        return _forceOfMadness;
    }
    public float GetLevelMadness()
    {
        return _currentLevelMadness;
    }

    public void AddLevelPsychopath(float amount)
    {
        _currentLevelMadness += amount;

        _currentLevelMadness = Mathf.Clamp(_currentLevelMadness,0, 100);
        ViewMadness.Instance.UpdateMadnessView(_currentLevelMadness);
        
    }

    public void PsychopathController()
    {

        AddLevelPsychopath(_madnessPerSecond);
        _forceOfMadness = _speedPlayer * _currentLevelMadness / 100;

        _currentTimeToAdd -= _currentTimeToAdd;

    }

    public bool CanAddLevelOfPsychopath()
    {
        if (_currentTimeToAdd < _nextTimeToAdd)
        {
            _currentTimeToAdd += Time.deltaTime;
            return false;
        }
        return true;
    }




}
