using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{

    public void Start()
    {
        SpriteRenderer renderer = transform.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = 1;
    }

    void Update()
    {

    }
}
