using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonScript : MonoBehaviour
{
    GameManager gameManager;

    int damage;
    public void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnButtonPress()
    {
        gameManager.DamagePlayer(damage);
    }
}