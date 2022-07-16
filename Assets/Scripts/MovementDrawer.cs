using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDrawer : MonoBehaviour
{
    private List<Vector3> points;
    private LineRenderer lr;

    private bool locked = false;
    public bool startFromPlayer = false;

    public void Start()
    {
        points = new List<Vector3>();
        transform.position = transform.parent.transform.position;
        lr = transform.GetComponent<LineRenderer>();
        lr.sortingOrder = 20;
        lr.sortingLayerName = "LineRenderer";
        lr.SetColors(Color.red, Color.red);
        lr.SetWidth(0.1f, 0.1f);
    }

    public void addMovementPoint(Vector3 newPoint)
    {
        if (startFromPlayer)
        {
            locked = true;
            if (points.Count == 0)
            {
                Add(newPoint);
            }
            else
            {
                int equalityIndex = -1;
                for (int i = 0; i < points.Count; i++)
                {
                    Vector3 lastPoint = points[i];
                    if (lastPoint.x == newPoint.x && lastPoint.y == newPoint.y)
                    {
                        equalityIndex = i;
                        break;
                    }
                }
                if (equalityIndex == -1)
                {
                    Vector3 lastPoint = points[points.Count - 1];
                    if (System.Math.Abs(newPoint.x - lastPoint.x) + System.Math.Abs(newPoint.y - lastPoint.y) == 1)
                    {
                        Add(newPoint);
                        Debug.Log("Added new point!");
                    }
                }
                else
                {
                    int count = points.Count;
                    for (int i = count - 1; i > equalityIndex; i--)
                    {
                        points.RemoveAt(i);
                    }
                }
            }
            lr.positionCount = points.Count;
            locked = false;
        }
    }

    private void Add(Vector3 point)
    {
        points.Add(point);
        transform.position = point;
    }

    public void clear()
    {
        points.Clear();
        lr.positionCount = 0;
        startFromPlayer = false;
    }

    public void Update()
    {
        if (!locked)
        {
            for (int i = 0; i < points.Count; i++)
            {
                lr.SetPosition(i, points[i]);
            }
        }
    }

    public List<Vector3> GetFinalMovement()
    {
        List<Vector3> copy = new List<Vector3>();
        copy.AddRange(points);
        return copy;
    }
}
