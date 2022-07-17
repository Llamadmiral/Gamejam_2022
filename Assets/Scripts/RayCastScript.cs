using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{

    private static readonly Logger LOG = new Logger(typeof(RayCastScript));
    private GameObject selectedObject;
    private IDraggableObject draggableObject;
    private IMouseOverDraggable mouseOverDraggable;
    private Vector3 offset;

    public bool logEnabled;
    public void Start()
    {
        Application.targetFrameRate = 60;
        LOG.enabled = logEnabled;
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (MouseButtonDownDrag(mousePosition))
        {
            draggableObject = selectedObject.GetComponent<IDraggableObject>();
            if (draggableObject == null)
            {
                mouseOverDraggable = selectedObject.GetComponent<IMouseOverDraggable>();
            }
        }
        else if (draggableObject == null && MouseOverButtonDrag(mousePosition))
        {
            mouseOverDraggable = selectedObject.GetComponent<IMouseOverDraggable>();
        }
        if (draggableObject != null)
        {
            LOG.Log("Found draggable object, calling OnDrag()");
            draggableObject.OnDrag(offset);
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
            GameObject targetObject = null;
            Collider2D[] results = Physics2D.OverlapPointAll(mousePosition);
            if (results.Length > 0)
            {
                targetObject = results[0].gameObject;
                float maxZ = targetObject.transform.position.z;
                for (int i = 1; i < results.Length; i++)
                {
                    GameObject gameObject = results[i].gameObject;
                    float z = gameObject.transform.position.z;
                    LOG.Log("Considering: " + gameObject + ", with Z: " + z);
                    if (z > maxZ)
                    {
                        maxZ = z;
                        targetObject = gameObject;
                    }
                }
            }
            if (targetObject != null)
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
