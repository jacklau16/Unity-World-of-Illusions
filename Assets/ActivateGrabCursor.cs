using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGrabCursor : MonoBehaviour
{
    private void OnMouseEnter()
    {
        CursorController.instance.ActivateGrabOpenCursor();
    }

    private void OnMouseDrag()
    {
        CursorController.instance.ActivateGrabCloseCursor();
    }

    private void OnMouseExit()
    {
        CursorController.instance.ActivateDefaultCursor();
    }
}
