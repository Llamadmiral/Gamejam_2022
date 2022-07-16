using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperty : MonoBehaviour, IMouseOverDraggable
{
    public bool walkable;

    public List<Sprite> variations = new List<Sprite>();

    private TestTileSpawner spawner;

    public void Start()
    {
        spawner = transform.parent.GetComponent<TestTileSpawner>();
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = variations[Random.Range(0, variations.Count)];
    }

    public void onDrag()
    {
        if (walkable)
        {
            spawner.addMovementPoint(transform.position);
        }
    }
}
