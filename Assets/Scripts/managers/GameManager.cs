using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TileManager testTileSpawner;
    public Player player;
    public DiceManager diceManager;
    public InventoryManager inventoryManager;
    public ModifierInsertManager modifierInsertManager;
    public TileManager tileManager;
    public MovementManager movementManager;
    void Start()
    {
        gameObject.tag = "GameManager";
        testTileSpawner.spawnTiles();
        spawnPlayer();
    }

    private void spawnPlayer()
    {
        List<Tile> tiles = tileManager.GetWalkableTiles();
        Tile spawnTile = tiles[Random.Range(0, tiles.Count)];
        Vector3 pos = spawnTile.gameObject.transform.position;
        player.transform.position = new Vector3(pos.x, pos.y, 1);
    }

    public void startMovement()
    {
        List<Vector3> movementPoints = movementManager.GetFinalMovement();
        player.move(movementPoints);
        movementManager.clear();
    }

    public void DamagePlayer(int damage)
    {
        modifierInsertManager.healthInsert.Damage(damage);
    }

}