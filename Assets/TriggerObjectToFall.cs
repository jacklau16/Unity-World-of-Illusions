using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectToFall : MonoBehaviour
{
    private AudioSource audioClick;

    private void Start()
    {
        audioClick = gameObject.GetComponent<AudioSource>();
    }
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
        audioClick.Play();
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}
