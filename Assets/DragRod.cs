using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRod : MonoBehaviour
{
    public float mouseSensitivity = 3;
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;
    private bool isStillMouseOver = false;
    private float rodMinZPos = -4.8f;
    private float rodMaxZPos = 0.8f;

    private void OnMouseEnter()
    {
        Debug.Log("DragRod: onMouseEnter");
        isStillMouseOver = true;
        if (!isDragging)
            CursorController.instance.ActivateGrabOpenCursor();
    }

    private void OnMouseExit()
    {
        Debug.Log("DragRod: onMouseExit");
        isStillMouseOver = false;
        if (!isDragging)
            CursorController.instance.ActivateDefaultCursor();
    }

    private void OnMouseDown()
    {
        Debug.Log("DragRod: onMouseDown");
        isDragging = true;
        CursorController.instance.ActivateGrabCloseCursor();
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {

        //------Method 1-------
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        //Vector3 convertedCurPosition = transform.InverseTransformPoint(curPosition);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, convertedCurPosition.z);

        //------Method 2--------
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float newZ = transform.localPosition.z - mouseX;
        if (newZ < rodMinZPos)
            newZ = rodMinZPos;
        if (newZ > rodMaxZPos)
            newZ = rodMaxZPos;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZ);
        
    }

    private void OnMouseUp()
    {
        isDragging = false;
        if (isStillMouseOver)
            CursorController.instance.ActivateGrabOpenCursor();
        else
            CursorController.instance.ActivateDefaultCursor();
    }

}
