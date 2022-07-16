using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TestTileSpawner testTileSpawner;
    public GameObject playerPrefab;
    private Player player;
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
        GameObject playerObject = Instantiate(playerPrefab);
        player = playerObject.GetComponent<Player>();
        player.transform.position = new Vector3(0, 0, 0);
        playerObject.transform.parent = gameObject.transform;
    }

    public void startMovement()
    {
        List<Vector3> movementPoints = movementDrawer.GetFinalMovement();
        player.move(movementPoints);
        movementDrawer.clear();
    }

}