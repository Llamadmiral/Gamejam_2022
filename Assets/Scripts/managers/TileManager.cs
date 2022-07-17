using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tileWalkable;
    public GameObject leftWall;
    public GameObject middleWall;
    public GameObject rightWall;
    public GameObject bottomLeftWall;
    public GameObject bottomRightWall;
    public GameObject bottomLeftRepeatable;
    public GameObject bottomRightRepeatable;
    public GameObject bottomMLeft;
    public GameObject bottomMMiddle;
    public GameObject bottomMRight;

    public int width;
    public int height;

    public Dictionary<Vector3, TileProperty> tilemap = new Dictionary<Vector3, TileProperty>();
    private GameManager gameManager;

    public void Start()
    {
        GameObject obj = GameObject.FindWithTag("GameManager");
        gameManager = obj.GetComponent<GameManager>();
    }

    public void spawnTiles()
    {
        Vector3 position = transform.position;
        for (int x = 0; x < width; x++)
        {

            SpawnTileAt(Instantiate(middleWall), position + new Vector3(x, height + 1.5f, 0));
            if (x > 0 && x < width - 1)
            {
                SpawnTileAt(Instantiate(bottomMMiddle), position + new Vector3(x, -1, 0));
            }
            for (int y = 0; y < height; y++)
            {
                SpawnTileAt(Instantiate(tileWalkable), position + new Vector3(x, y, 0));
                if (x == 1 && y > 0)
                {
                    SpawnTileAt(Instantiate(bottomLeftRepeatable), position + new Vector3(-1, y, 0));
                }
                else if (x == width - 2 && y > 0)
                {
                    SpawnTileAt(Instantiate(bottomRightRepeatable), position + new Vector3(width, y, 0));
                }
            }
        }
        SpawnTileAt(Instantiate(bottomMLeft), position + new Vector3(0, -1, 0));
        SpawnTileAt(Instantiate(bottomMRight), position + new Vector3(width - 1, -1, 0));
        SpawnTileAt(Instantiate(leftWall), position + new Vector3(-0.5f, height + 1.5f, 0));
        SpawnTileAt(Instantiate(rightWall), position + new Vector3(width - 0.5f, height + 1.5f, 0));
        SpawnTileAt(Instantiate(bottomLeftWall), position + new Vector3(-1, -0.5f, 0));
        SpawnTileAt(Instantiate(bottomRightWall), position + new Vector3(width, -0.5f, 0));
    }

    public void addMovementPoint(Vector3 point)
    {
        gameManager.movementDrawer.addMovementPoint(point);
    }

    private void SpawnTileAt(GameObject tile, Vector3 target)
    {
        tile.transform.position = target + new Vector3(-13.5f, 0, 0);
        tile.transform.parent = transform;
    }

}


