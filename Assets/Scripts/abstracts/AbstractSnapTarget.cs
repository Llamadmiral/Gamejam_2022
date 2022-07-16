using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSnapTarget : MonoBehaviour, ISnapTarget
{
    public Vector2 provideSnapTarget(Vector3 position)
    {
        List<Vector2> gridCenterPoints = GetGridCenterPoints();
        int mini = 0;
        float minDistance = System.MathF.Sqrt(System.Math.Abs(gridCenterPoints[0].x - position.x) + System.Math.Abs(gridCenterPoints[0].y - position.y));
        for (int i = 1; i < gridCenterPoints.Count; i++)
        {
            float currentDistance = System.MathF.Sqrt(System.MathF.Pow(gridCenterPoints[i].x - position.x, 2) + System.MathF.Pow(gridCenterPoints[i].y - position.y, 2));
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                mini = i;
            }
        }
        return gridCenterPoints[mini];
    }

    public abstract List<Vector2> GetGridCenterPoints();

    public virtual bool Accept(System.Type clazz)
    {
        return true;
    }

    public virtual void OnSnap(GameObject attachedObject)
    {
        //NOOP
    }
}
