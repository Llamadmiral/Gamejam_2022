using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierInsert : AbstractSnapTarget
{
    public GameObject icon;
    public Sprite iconSprite;
    public ModifierType modifierType;

    public List<Dice> attachedDice = new List<Dice>();

    public void Start()
    {
        icon = new GameObject();
        icon.transform.position = transform.position + new Vector3(0, 1.5f, 0);
        icon.AddComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer = icon.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = iconSprite;
        spriteRenderer.sortingOrder = 32;

        gameObject.AddComponent<BoxCollider2D>();
    }

    public override List<Vector2> GetGridCenterPoints()
    {
        List<Vector2> points = new List<Vector2>();
        points.Add(new Vector2(transform.position.x - 0.5F, transform.position.y - 0.5F));
        points.Add(new Vector2(transform.position.x + 0.5F, transform.position.y - 0.5F));
        points.Add(new Vector2(transform.position.x + 0.5F, transform.position.y + 0.5F));
        points.Add(new Vector2(transform.position.x - 0.5F, transform.position.y + 0.5F));
        return points;
    }

    public override void OnSnap(GameObject attachedObject)
    {
        Dice comp = attachedObject.GetComponent<Dice>();
        if (comp != null && !attachedDice.Contains(comp))
        {
            attachedDice.Add(comp);
        }
    }

    public override bool Accept(System.Type type)
    {
        return type.IsAssignableFrom(typeof(DraggableDice));
    }

    public void Disable()
    {
        icon.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        icon.SetActive(true);
        gameObject.SetActive(true);
    }


}



public enum ModifierType
{
    MOVEMENT,
    ATTACK,
    DEFENSE
}