using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggableObject
{
    Vector3 getPosition();
    void onDrag(Vector3 mouseOffset);
    void snapToTarget(Vector2 target);
}
