using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectToFall : MonoBehaviour
{
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
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}
