using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectToFall : MonoBehaviour
{
    public void OnMouseEnter()
    {
        CursorController.instance.ActivateClickCursor();
    }

    public void OnMouseExit()
    {
        CursorController.instance.ActivateDefaultCursor();
    }

    private void OnMouseDown()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}
