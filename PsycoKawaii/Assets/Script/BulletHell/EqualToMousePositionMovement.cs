using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualToMousePositionMovement : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        this.transform.position = worldPosition;
    }
}
