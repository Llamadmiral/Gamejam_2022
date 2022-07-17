using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

    private static readonly Logger LOG = new Logger(typeof(DiceManager));
    public Dice[] dices = new Dice[24];
    public Sprite[] sprites = new Sprite[24];

    public Dice dicePrefab;

    public GameManager gameManager;

    public bool logEnabled;

    public void Awake()
    {
        LOG.enabled = logEnabled;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < sprites.Length; i++)
        {
            Dice dice = Instantiate(dicePrefab);
            dice.id = i;
            dice.value = (i / 4) + 1;
            dice.SetSprite(sprites[i]);
            dice.transform.parent = transform;
            dices[i] = dice;
            LOG.Log("Dice created: " + dice);
            gameManager.inventoryManager.addDice(dice);
        }
    }
}