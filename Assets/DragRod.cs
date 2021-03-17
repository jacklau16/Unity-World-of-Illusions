using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRod : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    private void OnMouseDrag()
    {

        //------Method 1-------
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        //Vector3 convertedCurPosition = transform.InverseTransformPoint(curPosition);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, convertedCurPosition.z);

        //------Method 2--------
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - mouseX);
        
    }
}
