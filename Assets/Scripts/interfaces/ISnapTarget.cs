using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISnapTarget
{
    public Vector2 provideSnapTarget(Vector3 position);
}
