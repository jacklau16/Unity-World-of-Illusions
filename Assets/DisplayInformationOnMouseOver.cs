using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInformationOnMouseOver : MonoBehaviour
{
    public GameObject uiTextObj;
    public bool withDisplayDuration = false;
    public float displayDurationInSecond = 4.0f;

    private void Awake()
    {
        uiTextObj.SetActive(false);
    }

    private void OnMouseEnter()
    {
        uiTextObj.SetActive(true);
        // Wait for N seconds and hide the display object 
        StartCoroutine(HideText(displayDurationInSecond));
    }

    IEnumerator HideText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        uiTextObj.SetActive(false);
    }

    private void OnMouseExit()
    {
        uiTextObj.SetActive(false);
        CursorController.instance.ActivateDefaultCursor();
    }

}
