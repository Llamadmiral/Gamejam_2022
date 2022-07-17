using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDice : DraggableDice
{
    public Sprite[] sprites = new Sprite[6];

    private SpriteRenderer renderer;

    public void Awake()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetValue(int value)
    {
        this.value = value;
        if (value != 0)
        {
            renderer.sprite = sprites[this.value - 1];
        }
        else
        {
            renderer.sprite = null;
        }
    }

    public override void OnDrag(Vector3 mouseOffset)
    {
        //NOOP;
    }
}