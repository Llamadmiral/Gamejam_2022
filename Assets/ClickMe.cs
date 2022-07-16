using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMe : MonoBehaviour, IPointerDownHandler
{

    public void onMouseDown()
    {
        Debug.Log("Called on mouse down");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointer down while over the Collider!");
    }
}
