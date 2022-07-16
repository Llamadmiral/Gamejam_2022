using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierInsert : AbstractSnapTarget
{
    public GameObject icon;
    public ModifierType modifierType;

    public List<Dice> attachedDice = new List<Dice>();

    public void Start()
    {
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
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }


}



public enum ModifierType
{
    MOVEMENT,
    ATTACK,
    DEFENSE
}