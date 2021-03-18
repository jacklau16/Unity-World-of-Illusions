using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController instance;

    public Texture2D cursorClick;
    public Texture2D cursorGrabOpen;
    public Texture2D cursorGrabClose;
    public Texture2D cursorDefault;
    public Image uICursorImage;

    private void Awake()
    {
        instance = this;
        instance.ActivateDefaultCursor();
    }

    public void showUICursorImage()
    {
        uICursorImage.enabled = true;
    }

    public void hideUICursorImage()
    {
        uICursorImage.enabled = false;
    }

    public void ActivateClickCursor()
    {
        Cursor.SetCursor(cursorClick, new Vector2(25, 0), CursorMode.Auto);
    }

    public void ActivateGrabOpenCursor()
    {
        Cursor.SetCursor(cursorGrabOpen, new Vector2(cursorGrabOpen.width/2, cursorGrabOpen.height/2), CursorMode.Auto);
    }

    public void ActivateGrabCloseCursor()
    {
        Cursor.SetCursor(cursorGrabClose, new Vector2(cursorGrabClose.width / 2, cursorGrabClose.height / 2), CursorMode.Auto);
    }

    public void ActivateDefaultCursor()
    {
        Cursor.SetCursor(cursorDefault, new Vector2(cursorDefault.width / 2, cursorDefault.height / 2), CursorMode.Auto);
    }
}
