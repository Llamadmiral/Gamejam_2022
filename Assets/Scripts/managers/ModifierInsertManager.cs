using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierInsertManager : MonoBehaviour
{
    public ModifierInsert movementInsert;
    public ModifierInsert attakcInsert;
    public ModifierInsert defenseInsert;
    public GameObject greyscreen;

    public GameObject draggableDicePrefab;

    public List<ModifierInsert> inserts = new List<ModifierInsert>();

    public List<DraggableDice> draggableDices = new List<DraggableDice>();

    private bool active = true;
    public void Start()
    {
        setupInsert(movementInsert);
        setupInsert(attakcInsert);
        setupInsert(defenseInsert);
        RollDices();
    }

    private void setupInsert(ModifierInsert insertPrefab)
    {
        ModifierInsert insert = Instantiate(insertPrefab);
        insert.gameObject.SetActive(true);
        insert.transform.position = new Vector3(-9 + inserts.Count * 8, 5, 0);
        insert.transform.parent = transform;
        inserts.Add(insert);
    }

    public void LockInChoices()
    {
        HideElements();
        greyscreen.SetActive(false);
    }

    public void HideElements()
    {
        foreach (ModifierInsert insert in inserts)
        {
            insert.Disable();
        }
        foreach (DraggableDice draggableDice in draggableDices)
        {
            Debug.Log("Destroying!");
            Object.DestroyImmediate(draggableDice.gameObject);
        }
    }

    public void RollDices()
    {
        DraggableDice draggableDice = Instantiate(draggableDicePrefab).GetComponent<DraggableDice>();
        draggableDice.transform.position = new Vector3(3, 10, 0);
        draggableDice.transform.parent = transform;
        draggableDices.Add(draggableDice);
    }

}