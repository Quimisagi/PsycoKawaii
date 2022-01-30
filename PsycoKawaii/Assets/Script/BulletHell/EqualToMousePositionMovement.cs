using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualToMousePositionMovement : MonoBehaviour
{
    private bool _isActive;

    private void Start()
    {
        Goodness.notifyDestroyed += () => _isActive = false;
        Timer.notifyTimeRanOut += () => _isActive = false;
        GameActivator.startGame += ActiveSoul;
    }

    private void ActiveSoul()
    {
        _isActive = true;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Goodness.notifyDestroyed -= () => _isActive = false;
        Timer.notifyTimeRanOut -= () => _isActive = false;
    }
    void Update()
    { 
        if(_isActive)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            this.transform.position = worldPosition;
        }
    }
}
