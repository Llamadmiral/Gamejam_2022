using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggableObject
{
    Vector3 getPosition();
    void OnDrag(Vector3 mouseOffset);
    void snapToTarget(Vector2 target);
}
