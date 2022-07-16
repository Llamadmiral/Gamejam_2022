using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperty : MonoBehaviour, IMouseOverDraggable
{
    public bool walkable;

    private bool dragged = false;

    private TestTileSpawner spawner;

    public void Start()
    {
        spawner = transform.parent.GetComponent<TestTileSpawner>();
    }

    public void onDrag()
    {
        if (walkable && !dragged)
        {
            spawner.addMovementPoint(transform.position);
        }
    }
}
