using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierInsertManager : MonoBehaviour
{

    private static readonly Logger LOG = new Logger(typeof(ModifierInsertManager));
    public ModifierInsert movementInsert;
    public ModifierInsert attakcInsert;
    public ModifierInsert defenseInsert;
    public HealthModifierInsert healthInsert;
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
        SetupInsert(movementInsert);
        SetupInsert(attakcInsert);
        SetupInsert(defenseInsert);
        SetupInsert(healthInsert);
        healthInsert.InitHealthDices();
        RollDices();
    }

    private void SetupInsert(ModifierInsert insert)
    {
        insert.gameObject.SetActive(true);
        insert.transform.position = new Vector3(-13 + inserts.Count * 4, -7, 0);
        insert.InitGridPoints();
        inserts.Add(insert);
    }

    public void LockInChoices()
    {
        greyscreen.SetActive(false);
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
                draggableDice.transform.position = new Vector3(-12 + i * 2, -7, 1);
                draggableDice.transform.parent = transform;
                SpriteRenderer renderer = draggableDice.gameObject.GetComponent<SpriteRenderer>();
                renderer.sprite = rolledDice.sprite;
                draggableDices.Add(draggableDice);
                i++;
            }
        }
    }

}