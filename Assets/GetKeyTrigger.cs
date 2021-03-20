using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyTrigger : MonoBehaviour
{
    public GameObject keyPicture;
    public Material matWhite;

    // Start is called before the first frame update
    void Start()
    {
        keyPicture.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        CursorController.instance.ActivateClickCursor();
        Debug.Log("GetKey: Correct Position!");
    }

    public void OnMouseExit()
    {
        CursorController.instance.ActivateDefaultCursor();
    }

    private void OnMouseDown()
    {
        Debug.Log("GetKey!");
        GameObject[] keyPllars = GameObject.FindGameObjectsWithTag("Key Puzzle");
        foreach (GameObject keyPillar in keyPllars)
        {
            // Change the material of the pillars showing the key picture to white
            keyPillar.GetComponent<Renderer>().material = matWhite;
        }

        keyPicture.SetActive(true);
        UIController.instance.showImageKey(true);
        GlobalState.hasKey = true;
        StartCoroutine(HideObject(4));

    }

    IEnumerator HideObject(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        keyPicture.SetActive(false);
        gameObject.SetActive(false);
    }
}
