using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDice : DraggableDice
{
    private static readonly Logger LOG = new Logger(typeof(HealthDice));
    public Sprite[] sprites = new Sprite[6];

    private SpriteRenderer spriteRenderer;
    public void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetValue(int value)
    {
        this.value = value;
        if (value != 0)
        {
            spriteRenderer.sprite = sprites[this.value - 1];
        }
        else
        {
            spriteRenderer.sprite = null;
        }
    }

    public void SetLog(bool value)
    {
        LOG.enabled = value;
    }

    public int Damage(int amount)
    {
        int oldValue = this.value;
        int newValue = System.Math.Max(0, this.value - amount);
        SetValue(newValue);
        LOG.Log(string.Format("Damaged with {0} from {1} to {2}", amount, oldValue, newValue));
        return oldValue - newValue;
    }

    public override void OnDrag(Vector3 mouseOffset)
    {
        //NOOP;
    }
}