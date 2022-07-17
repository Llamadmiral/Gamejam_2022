using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMouseOverDraggable
{

    private static readonly Logger LOG = new Logger(typeof(Player));

    public GameManager gameManager;

    private Queue<Vector3> pendingMovement = new Queue<Vector3>();

    private int moveCooldown = 0;

    public bool logEnabled;

    public void Start()
    {
        LOG.enabled = logEnabled;
        SpriteRenderer spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 10;
    }

    public void Update()
    {
        if (pendingMovement.Count > 0 && moveCooldown == 0)
        {
            Vector3 nextMove = pendingMovement.Dequeue();
            transform.position = new Vector3(nextMove.x, nextMove.y, 1);
            moveCooldown = 15;
        }
        if (moveCooldown > 0)
        {
            moveCooldown = moveCooldown - 1;
        }
    }

    public void onDrag()
    {
        LOG.Log("OnDrag() called on player!");
        gameManager.movementManager.startFromPlayer = true;
        gameManager.movementManager.addMovementPoint(transform.position);
    }

    public void move(List<Vector3> points)
    {
        foreach (Vector3 point in points)
        {
            pendingMovement.Enqueue(point);
        }
    }
}
