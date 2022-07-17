using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifierInsert : ModifierInsert
{
    public HealthDice healthDicePrefab;

    public void InitHealthDices()
    {
        for (int i = 0; i < 4; i++)
        {
            HealthDice healthDice = Instantiate(healthDicePrefab);
            healthDice.SetValue(6);
            healthDice.transform.parent = transform;
            AddDice(healthDice);
        }
    }

    public override bool Accept(Type type)
    {
        return false;
    }

}