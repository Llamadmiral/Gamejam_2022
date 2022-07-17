using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableDice : MonoBehaviour, IDraggableObject
{
    public int value = 6;

    public Vector3 getPosition()
    {
        return transform.position;
    }
    public void onDrag(Vector3 mouseOffset)
    {
        Vector3 result = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
        transform.position = new Vector3(result.x, result.y, 1);
    }
    public void snapToTarget(Vector2 target)
    {
        transform.position = new Vector3(target.x, target.y, 1);
    }

}