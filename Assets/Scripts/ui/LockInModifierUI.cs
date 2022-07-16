using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockInModifierUI : MonoBehaviour
{

    ModifierInsertManager manager;
    public void Start()
    {
        manager = GameObject.FindWithTag("ModifierInsertManager").GetComponent<ModifierInsertManager>();
    }

    public void OnButtonPress()
    {
        Debug.Log("Clicked!");
        manager.LockInChoices();
        gameObject.SetActive(false);
    }
}
