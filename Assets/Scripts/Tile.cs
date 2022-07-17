using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IMouseOverDraggable
{
    public bool walkable;

    public List<Sprite> variations = new List<Sprite>();

    private TileManager spawner;

    public void Start()
    {
        spawner = transform.parent.GetComponent<TileManager>();
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
