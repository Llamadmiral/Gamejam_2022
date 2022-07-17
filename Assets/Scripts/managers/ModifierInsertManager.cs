using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierInsertManager : MonoBehaviour
{

    private static readonly Logger LOG = new Logger(typeof(ModifierInsertManager));
    public ModifierInsert movementInsert;
    public ModifierInsert attakcInsert;
    public ModifierInsert defenseInsert;
    public GameObject greyscreen;

    public GameObject draggableDicePrefab;

    public List<ModifierInsert> inserts = new List<ModifierInsert>();

    public List<DraggableDice> draggableDices = new List<DraggableDice>();

    public GameManager gameManager;

    private bool active = true;

    public bool logEnabled;
    public void Start()
    {
        LOG.enabled = logEnabled;
        setupInsert(movementInsert);
        setupInsert(attakcInsert);
        setupInsert(defenseInsert);
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
            Object.DestroyImmediate(draggableDice.gameObject);
        }
        draggableDices.Clear();
    }

    public void RollDices()
    {
        Dice[] dices = gameManager.diceManager.dices;
        List<int> rolledDices = new List<int>();
        int i = 0;
        while (i < 4)
        {
            Dice rolledDice = dices[Random.Range(0, 24)];
            LOG.Log("Rolled dice: " + rolledDice);
            if (!rolledDices.Contains(rolledDice.id))
            {
                rolledDices.Add(rolledDice.id);
                DraggableDice draggableDice = Instantiate(draggableDicePrefab).GetComponent<DraggableDice>();
                draggableDice.transform.position = new Vector3(-12 + i * 2, -7, 0);
                draggableDice.transform.parent = transform;
                SpriteRenderer renderer = draggableDice.gameObject.GetComponent<SpriteRenderer>();
                renderer.sprite = rolledDice.sprite;
                draggableDices.Add(draggableDice);
                i++;
            }
        }
    }

}