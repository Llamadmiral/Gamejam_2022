using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour, ISnapTarget
{

    private List<Vector2> gridCenterPoints = new List<Vector2>();
    void Start()
    {
        float topLeftX = transform.position.x - 1.5f;
        float topLeftY = transform.position.y - 2.5f;
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                Vector2 gridCenterPoint = new Vector2(topLeftX + x, topLeftY + y);
                gridCenterPoints.Add(gridCenterPoint);
            }
        }
    }

    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        transform.position = new Vector3(cameraPosition.x + 12, cameraPosition.y - 6, 0);
    }

    public Vector2 provideSnapTarget(Vector3 position)
    {
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
}
