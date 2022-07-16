using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileSpawner : MonoBehaviour
{
    public GameObject tileWalkable;
    public GameObject tileWall;

    private GameManager manager;

    public void Start()
    {
        GameObject obj = GameObject.FindWithTag("GameManager");
        manager = obj.GetComponent<GameManager>();
    }

    public void spawnTiles()
    {
        Vector3 position = transform.position;
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                GameObject walkableTile = Instantiate(tileWalkable);
                walkableTile.transform.position = position + new Vector3(x, y, 0);
                walkableTile.transform.parent = transform;
            }
        }
    }

    public void addMovementPoint(Vector3 point)
    {
        manager.movementDrawer.addMovementPoint(point);
    }

}


