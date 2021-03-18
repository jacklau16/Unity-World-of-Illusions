using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Texture2D cursorClick;
    public Texture2D cursorGrabOpen;
    public Texture2D cursorGrabClose;
    public Texture2D cursorDefault;
    public Image uIKeyImage;

    private void Awake()
    {
        instance = this;
        instance.hideKeyImage();
    }

    public void showKeyImage()
    {
        uIKeyImage.enabled = true;
    }

    public void hideKeyImage()
    {
        uIKeyImage.enabled = false;
    }

}
