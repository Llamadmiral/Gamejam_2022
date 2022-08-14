using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifierInsert : ModifierInsert
{
    private static readonly Logger LOG = new Logger(typeof(HealthModifierInsert));
    public HealthDice healthDicePrefab;

    public int health = 24;

    public bool logEnabled;

    public int damage;

    public new void Start()
    {
        LOG.enabled = logEnabled;
    }

    public void InitHealthDices()
    {
        for (int i = 0; i < 4; i++)
        {
            HealthDice healthDice = Instantiate(healthDicePrefab);
            healthDice.SetValue(6);
            healthDice.transform.parent = transform;
            healthDice.SetLog(logEnabled);
            AddDice(healthDice);
        }
    }

    public override bool Accept(Type type)
    {
        return false;
    }

    public void OnButtonPress()
    {
        Damage(damage);
    }

    public void Damage(int damage)
    {
        LOG.Log("Damaging the player for " + damage + ", current health: " + health);
        int remainingDamage = damage;
        health -= damage;
        for (int i = 3; i >= 0; i--)
        {
            HealthDice healthDice = slots[i].GetComponent<HealthDice>();
            if (healthDice.value > 0)
            {
                remainingDamage -= healthDice.Damage(remainingDamage);
            }
            if (remainingDamage <= 0)
            {
                break;
            }
        }
        if (health > 0)
        {
            LOG.Log("Player is kill :(");
        }
    }

}