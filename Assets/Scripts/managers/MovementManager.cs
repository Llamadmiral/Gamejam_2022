using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    private static readonly Logger LOG = new Logger(typeof(MovementManager));
    private List<Vector3> points = new List<Vector3>();
    private LineRenderer lr;

    private bool locked = false;
    public bool startFromPlayer = false;

    public bool logEnabled;

    public void Start()
    {
        LOG.enabled = logEnabled;
        transform.position = transform.parent.transform.position;
        lr = transform.GetComponent<LineRenderer>();
        lr.sortingOrder = 20;
        lr.sortingLayerName = "LineRenderer";
        lr.startColor = Color.red;
        lr.endColor = Color.red;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
    }

    public void addMovementPoint(Vector3 newPoint)
    {
        LOG.Log("Considering point: " + newPoint);
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
                    int distance = (int)(System.Math.Abs(newPoint.x - lastPoint.x) + System.Math.Abs(newPoint.y - lastPoint.y));
                    if (distance == 1)
                    {
                        Add(newPoint);
                    }
                    else
                    {
                        LOG.Log(
                            "Not adding point, because it is further away than one tile! Last tile: " + lastPoint
                        + ", current tile: " + newPoint
                        + ", distance: " + distance
                        );
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
