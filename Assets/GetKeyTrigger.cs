using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyTrigger : MonoBehaviour
{
    public GameObject keyPicture;

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
        GameObject[] keyWalls = GameObject.FindGameObjectsWithTag("Key Puzzle");
        foreach (GameObject keyWall in keyWalls)
        {
            Material mat = keyWall.GetComponent<Renderer>().material;
            Destroy(mat);
        }

        keyPicture.SetActive(true);
        UIController.instance.showKeyImage();
        StartCoroutine(HideObject(3));

    }

    IEnumerator HideObject(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        keyPicture.SetActive(false);
        gameObject.SetActive(false);
    }
}
