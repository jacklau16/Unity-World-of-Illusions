using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetTrigger : MonoBehaviour
{
    //private GameObject fpController;
    public string fpControllerTag = "FirstPersonController";

    private void Start()
    {
       // fpController = GameObject.FindGameObjectWithTag("FirstPersonController");   
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Carpet ON: "+other.gameObject.tag);
        if (other.gameObject.tag == fpControllerTag)
        {
            GlobalState.onCarpet = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Carpet OFF:" + other.gameObject.tag);
        if (other.gameObject.tag == fpControllerTag)
        {
            GlobalState.onCarpet = false;
        }
    }
}
