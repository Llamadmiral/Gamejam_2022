using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile tileWalkable;
    public Tile leftWall;
    public Tile middleWall;
    public Tile rightWall;
    public Tile bottomLeftWall;
    public Tile bottomRightWall;
    public Tile bottomLeftRepeatable;
    public Tile bottomRightRepeatable;
    public Tile bottomMLeft;
    public Tile bottomMMiddle;
    public Tile bottomMRight;
    public int width;
    public int height;
    public Dictionary<Vector3, Tile> tilemap = new Dictionary<Vector3, Tile>();
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

            if (x > 0 && x < width - 1)
            {
                SpawnTileAt(Instantiate(bottomMMiddle), position + new Vector3(x, -1, 0));
                SpawnTileAt(Instantiate(middleWall), position + new Vector3(x, height + 1.5f, 0));
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

    public List<Tile> GetWalkableTiles()
    {
        List<Tile> tiles = new List<Tile>();
        foreach (var item in tilemap)
        {
            Tile tile = item.Value;
            if (tile.walkable)
            {
                tiles.Add(tile);
            }
        }
        return tiles;
    }

    private void SpawnTileAt(Tile tile, Vector3 target)
    {
        tile.transform.position = target + new Vector3(-13.5f, 0.5f, 0);
        tile.transform.parent = transform;
        tilemap.Add(target, tile);
    }

}


