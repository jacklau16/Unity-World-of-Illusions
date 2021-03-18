using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private Animator doorAnimator;

    void Start()
    {
        doorAnimator = gameObject.GetComponent<Animator>();
        doorAnimator.SetBool("hasKey", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetBool("hasKey", true);
        Debug.Log("Triggered!!");
    }
}
