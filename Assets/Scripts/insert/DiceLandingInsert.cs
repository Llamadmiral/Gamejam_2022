using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceLandingInsert : ModifierInsert
{

    private static readonly Logger LOG = new Logger(typeof(DiceLandingInsert));
    public List<DraggableDice> draggableDices = new List<DraggableDice>();
    public GameObject draggableDicePrefab;
    public GameManager gameManager;

    public bool logEnabled;

    public void Awake()
    {
        LOG.enabled = logEnabled;
    }

    public override void InitGridPoints()
    {
        gridPoints.Add(new Vector2(transform.position.x - 1F, transform.position.y + 0.5F));
        gridPoints.Add(new Vector2(transform.position.x, transform.position.y + 0.5F));
        gridPoints.Add(new Vector2(transform.position.x + 1F, transform.position.y + 0.5F));
        gridPoints.Add(new Vector2(transform.position.x - 1F, transform.position.y - 0.5F));
        gridPoints.Add(new Vector2(transform.position.x, transform.position.y - 0.5F));
        gridPoints.Add(new Vector2(transform.position.x + 1F, transform.position.y - 0.5F));
    }

    public void RollDices()
    {
        Dice[] dices = gameManager.diceManager.dices;
        List<int> rolledDices = new List<int>();
        List<int> takenDicePositions = new List<int>();
        int i = 0;
        while (i < 4)
        {
            Dice rolledDice = dices[Random.Range(0, 24)];
            int pos = Random.Range(0, 6);
            if (!rolledDices.Contains(rolledDice.id) && !takenDicePositions.Contains(pos))
            {
                LOG.Log("Rolled dice: " + rolledDice + " at: " + pos);
                rolledDices.Add(rolledDice.id);
                takenDicePositions.Add(pos);
                DraggableDice draggableDice = Instantiate(draggableDicePrefab).GetComponent<DraggableDice>();
                Vector2 dicePosition = gridPoints[pos];
                draggableDice.transform.position = new Vector3(dicePosition.x, dicePosition.y, 1);
                draggableDice.transform.parent = transform;
                SpriteRenderer renderer = draggableDice.gameObject.GetComponent<SpriteRenderer>();
                renderer.sprite = rolledDice.sprite;
                draggableDices.Add(draggableDice);
                i++;
            }
        }
    }
}