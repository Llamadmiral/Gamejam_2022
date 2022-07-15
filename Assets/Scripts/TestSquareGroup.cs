using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TestSquareGroup : MonoBehaviour, IDraggableObject
{
    private List<GameObject> squares = new List<GameObject>();

    public GameObject squarePrefab;
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject children = Instantiate(squarePrefab);
            children.transform.position = transform.position + new Vector3(1 * i, 0, 0);
            squares.Add(children);
        }

        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.SetPath(0, new List<Vector2>());
        List<Vector2> path = new List<Vector2>();
        path.Add(new Vector2(-0.5f, 0f));
        path.Add(new Vector2(4.5f, 0.5f));
        path.Add(new Vector2(4.5f, -0.5f));
        path.Add(new Vector2(-0.5f, -0.5f));
        Debug.Log(string.Join(", ", path));
        polygonCollider.SetPath(0, path.ToArray());

    }

    public void onDrag(Vector3 mouseOffset)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
        for (int i = 0; i < squares.Count; i++)
        {
            GameObject square = squares[i];
            square.transform.position = new Vector3(transform.position.x + i, transform.position.y, 0);
        }
    }
}
