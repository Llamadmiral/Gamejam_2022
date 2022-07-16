using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TestTileSpawner testTileSpawner;
    public Player player;
    private bool tested = false;

    public MovementDrawer movementDrawer;
    void Start()
    {
        gameObject.tag = "GameManager";
        testTileSpawner.spawnTiles();
        spawnPlayer();
    }

    private void spawnPlayer()
    {
        player.transform.position = new Vector3(0, 0, -1);
    }

    public void startMovement()
    {
        List<Vector3> movementPoints = movementDrawer.GetFinalMovement();
        player.move(movementPoints);
        movementDrawer.clear();
    }

}