using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierInsert : AbstractSnapTarget
{
    public ModifierType modifierType;
    protected List<Vector2> gridPoints = new List<Vector2>();
    protected List<DraggableDice> slots = new List<DraggableDice>();
    public void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    public virtual void InitGridPoints()
    {
        gridPoints.Add(new Vector2(transform.position.x - 0.5F, transform.position.y + 0.5F));
        gridPoints.Add(new Vector2(transform.position.x + 0.5F, transform.position.y + 0.5F));
        gridPoints.Add(new Vector2(transform.position.x - 0.5F, transform.position.y - 0.5F));
        gridPoints.Add(new Vector2(transform.position.x + 0.5F, transform.position.y - 0.5F));
    }

    public override List<Vector2> GetGridCenterPoints()
    {
        return gridPoints;
    }

    public override void OnSnap(GameObject attachedObject)
    {
        DraggableDice comp = attachedObject.GetComponent<DraggableDice>();
        if (comp != null)
        {
            slots.Add(comp);
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

    public virtual void AddDice(DraggableDice draggableDice)
    {
        if (slots.Count == 0)
        {
            Vector2 pos = gridPoints[0];
            slots.Add(draggableDice);
            draggableDice.transform.position = new Vector3(pos.x, pos.y, 1);
        }
        else
        {
            Vector2 pos = gridPoints[slots.Count];
            draggableDice.transform.position = new Vector3(pos.x, pos.y, 1);
            slots.Add(draggableDice);
        }
    }

}