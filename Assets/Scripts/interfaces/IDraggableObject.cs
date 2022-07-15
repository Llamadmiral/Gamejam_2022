using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggableObject
{
    void onDrag(Vector3 mouseOffset);
}
