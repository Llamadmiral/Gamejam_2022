using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockInModifierUI : MonoBehaviour
{

    GameManager gameManager;
    public void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnButtonPress()
    {
        gameManager.modifierInsertManager.LockInChoices();
        gameObject.SetActive(false);
    }
}
