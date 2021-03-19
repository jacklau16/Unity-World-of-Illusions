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
    public Image uiImageKey;

    public GameObject uiTextIntro;

    private void Awake()
    {
        instance = this;
        instance.showImageKey(false);
        //instance.showTextIntro(false);
    }


    public void showTextIntro(bool show)
    {
        uiTextIntro.SetActive(show);
    }


    public void showImageKey(bool show)
    {
        uiImageKey.enabled = show;
    }

}