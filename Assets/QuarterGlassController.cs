using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterGlassController : MonoBehaviour
{
    public GameObject quarterGlass;
    private Animator glassAnimator;
    void Start()
    {
        glassAnimator = quarterGlass.GetComponent<Animator>();
        glassAnimator.SetBool("IsTriggered", false);
    }

    private void OnMouseEnter()
    {
        CursorController.instance.ActivateClickCursor();
    }

    private void OnMouseExit()
    {
        CursorController.instance.ActivateDefaultCursor();
    }

    private void OnMouseDown()
    {
        glassAnimator.SetBool("IsTriggered", true);
        Debug.Log("Triggered!!");
    }
}
