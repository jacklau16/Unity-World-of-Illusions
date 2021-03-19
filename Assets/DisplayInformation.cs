using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInformation : MonoBehaviour
{
    public GameObject uiTextObj;
    public float displayDurationInSecond = 4.0f;

    private void Awake()
    {
        uiTextObj.SetActive(false);
    }

    private void OnMouseEnter()
    {
        CursorController.instance.ActivateClickCursor();
    }

    private void OnMouseExit()
    {
        uiTextObj.SetActive(false);
        CursorController.instance.ActivateDefaultCursor();
    }

    private void OnMouseDown()
    {
        uiTextObj.SetActive(true);

        // Wait for N seconds and hide the display object 
       // StartCoroutine(HideObjects(displayDurationInSecond));
    }

    IEnumerator HideObjects(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        uiTextObj.SetActive(false);
    }
}
