using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMouseOverDraggable
{
    private GameManager manager;

    private bool dragged = false;

    private Queue<Vector3> pendingMovement = new Queue<Vector3>();

    private int moveCooldown = 0;

    void Start()
    {
        SpriteRenderer spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 10;
        manager = transform.parent.GetComponent<GameManager>();
    }

    public void Update()
    {
        if (pendingMovement.Count > 0 && moveCooldown == 0)
        {
            Vector3 nextMove = pendingMovement.Dequeue();
            transform.position = nextMove;
            moveCooldown = 15;
        }
        if (moveCooldown > 0)
        {
            moveCooldown = moveCooldown - 1;
        }
    }

    public void onDrag()
    {
        if (!dragged)
        {
            manager.movementDrawer.startFromPlayer = true;
            manager.movementDrawer.addMovementPoint(transform.position);
        }
    }

    public void move(List<Vector3> points)
    {
        foreach (Vector3 point in points)
        {
            pendingMovement.Enqueue(point);
        }
    }
}
