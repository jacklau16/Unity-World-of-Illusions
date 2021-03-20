using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2InteractionTrigger : MonoBehaviour
{
    public Transform masterObject;
    //public Transform slaveObject;
    public string slaveObjectTag = "FirstPersonController";
    public GameObject displayObject;
    //public Camera currentCamera;
    public string currentCameraTag = "MainCamera";

    public GameObject uiTextPressEscHint;
    public GameObject uiTextInstruction;
    public float speed = 20f;
    public float cameraRotateX = 27f;
    public float cameraRotateY = 0f;


    private Vector3 targetPosition;
    private Vector3 offset;
    private CharacterController _controller;
    private GameObject currentCamera;
    private AudioSource audioClick;
    private float step;

    private void Awake()
    {
        displayObject.SetActive(false);
        //_controller = slaveObject.GetComponent<CharacterController>();
        currentCamera = GameObject.FindGameObjectWithTag(currentCameraTag);
        //currentCamera = Camera.current.GetComponent<Camera>();
        _controller = GameObject.FindGameObjectWithTag(slaveObjectTag).GetComponent<CharacterController>();
        audioClick = gameObject.GetComponent<AudioSource>();
        targetPosition = masterObject.position;
        step = speed * Time.deltaTime;
    }

    private void OnMouseEnter()
    {
        CursorController.instance.ActivateClickCursor();
    }

    private void OnMouseExit()
    {
        CursorController.instance.ActivateDefaultCursor();
    }


    private void OnMouseDown()
    {
        GlobalState.isPlayerLockedAtRoom2 = true;
        Cursor.lockState = CursorLockMode.None;
        CursorController.instance.hideUICursorImage();
        Cursor.visible = true;
        audioClick.Play();
        uiTextPressEscHint.SetActive(true);
        uiTextInstruction.SetActive(true);
        // Wait for 4 seconds and show the display object 
        StartCoroutine(ShowObjects(4));
    }


    IEnumerator ShowObjects(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        displayObject.SetActive(true);
    }

    private void Update()
    {
        if (GlobalState.isPlayerLockedAtRoom2)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GlobalState.isPlayerLockedAtRoom2 = false;
                Cursor.lockState = CursorLockMode.Locked;
                CursorController.instance.showUICursorImage();
                Cursor.visible = false;
                uiTextPressEscHint.SetActive(false);
                uiTextInstruction.SetActive(false);
            }
            
            currentCamera.transform.rotation = Quaternion.RotateTowards(currentCamera.transform.rotation, Quaternion.Euler(cameraRotateX, cameraRotateY, 0), step); ;

            offset = targetPosition - _controller.transform.position;

            if (offset.magnitude > .1f)
            {
                _controller.enabled = false;
                _controller.transform.position = Vector3.MoveTowards(_controller.transform.position, targetPosition, step);
                _controller.enabled = true;
            }
            
        }

    }
}
