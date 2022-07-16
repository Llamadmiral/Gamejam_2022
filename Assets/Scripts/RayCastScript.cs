using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{

    private static readonly Logger LOG = new Logger(typeof(RayCastScript));
    private GameObject selectedObject;
    private IDraggableObject draggableObject;
    private IMouseOverDraggable mouseOverDraggable;
    Vector3 offset;

    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (MouseButtonDownDrag(mousePosition))
        {
            LOG.Log("Found for dragging");
            draggableObject = selectedObject.GetComponent<IDraggableObject>();
            if (draggableObject == null)
            {
                mouseOverDraggable = selectedObject.GetComponent<IMouseOverDraggable>();
            }
        }
        else if (draggableObject == null && MouseOverButtonDrag(mousePosition))
        {
            LOG.Log("Found for mouse over drag");
            mouseOverDraggable = selectedObject.GetComponent<IMouseOverDraggable>();
        }
        if (draggableObject != null)
        {
            LOG.Log("Found draggable object, calling OnDrag()");
            draggableObject.onDrag(offset);
        }
        else if (mouseOverDraggable != null)
        {
            LOG.Log("Found mouse over draggable object, calling OnDrag()");
            mouseOverDraggable.onDrag();
        }
        if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            if (draggableObject != null)
            {
                ReleaseDraggableObjectLogic(mousePosition);
            }
            else if (mouseOverDraggable != null)
            {
                ReleaseMouseOverDraggableLogic();
            }
            selectedObject = null;
            draggableObject = null;
            mouseOverDraggable = null;
        }
    }

    public bool MouseOverButtonDrag(Vector3 mousePosition)
    {
        return setMouseTarget(mousePosition, Input.GetMouseButton(0));
    }

    public bool MouseButtonDownDrag(Vector3 mousePosition)
    {
        return setMouseTarget(mousePosition, Input.GetMouseButtonDown(0));
    }

    public bool setMouseTarget(Vector3 mousePosition, bool pressed)
    {
        bool foundTarget = false;
        if (pressed)
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                foundTarget = true;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        return foundTarget;
    }

    public void ReleaseMouseOverDraggableLogic()
    {
        LOG.Log("ReleaseMouseOverDraggableLogic called!");
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().startMovement();
    }

    public void ReleaseDraggableObjectLogic(Vector3 mousePosition)
    {
        Collider2D[] results = Physics2D.OverlapPointAll(mousePosition);
        foreach (Collider2D collider2D in results)
        {
            GameObject obj = collider2D.transform.gameObject;
            if (obj != null)
            {
                ISnapTarget snapTarget = obj.GetComponent<ISnapTarget>();
                if (snapTarget != null && snapTarget.Accept(draggableObject.GetType()))
                {
                    Vector2 target = snapTarget.provideSnapTarget(draggableObject.getPosition());
                    draggableObject.snapToTarget(target);
                }
            }
        }
    }
}
