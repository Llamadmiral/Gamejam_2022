using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public Dice[] dices = new Dice[24];
    public Sprite[] sprites = new Sprite[24];

    public Dice dicePrefab;

    public void Start()
    {
        InventoryManager inventory = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
        for (int i = 0; i < sprites.Length; i++)
        {
            Dice dice = Instantiate(dicePrefab);
            dice.id = i;
            dice.value = (i / 4) + 1;
            dice.SetSprite(sprites[i]);
            dice.transform.parent = transform;
            inventory.addDice(dice);
        }
    }
}