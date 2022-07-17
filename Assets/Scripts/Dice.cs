using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int value;
    public int id;

    public Sprite sprite;

    public void SetSprite(Sprite sprite)
    {
        SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        this.sprite = sprite;
        renderer.sortingOrder = 10;
    }
}