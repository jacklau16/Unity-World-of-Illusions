using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterGlassController : MonoBehaviour
{
    public GameObject quarterGlass;
    private Animator glassAnimator;
    private AudioSource audioOpening;

    void Start()
    {
        glassAnimator = quarterGlass.GetComponent<Animator>();
        glassAnimator.SetBool("IsTriggered", false);
        audioOpening = quarterGlass.GetComponent<AudioSource>();
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
        audioOpening.Play();
        CursorController.instance.ActivateDefaultCursor();
        gameObject.SetActive(false);
    }
}
