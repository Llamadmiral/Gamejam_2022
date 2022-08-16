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
    public DiceLandingInsert diceLandingInsert;
    public GameObject greyscreen;
    public List<ModifierInsert> inserts = new List<ModifierInsert>();
    public GameManager gameManager;
    public bool logEnabled;
    public void Start()
    {
        LOG.enabled = logEnabled;
        SetupInsert(movementInsert, 0f);
        SetupInsert(attakcInsert, 4f);
        SetupInsert(defenseInsert, 8f);
        SetupInsert(diceLandingInsert, 12.5f);
        SetupInsert(healthInsert, 17f);
        healthInsert.InitHealthDices();
        diceLandingInsert.RollDices();
    }

    private void SetupInsert(ModifierInsert insert, float offset)
    {
        insert.gameObject.SetActive(true);
        insert.transform.position = new Vector3(-13 + offset + 1f, -7, 0);
        insert.InitGridPoints();
        inserts.Add(insert);
    }

    public void LockInChoices()
    {
        greyscreen.SetActive(false);
    }
}