using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1InteractionTrigger : MonoBehaviour
{
    public Transform masterObject;
    //public Transform slaveObject;
    public string slaveObjectTag = "FirstPersonController";
    public GameObject displayObject;
    //public Camera currentCamera;
    public string currentCameraTag = "MainCamera";
    public GameObject uiTextPressEscHint;
    public GameObject uiTextInstruction;
    public float speed = 100f;
    public float cameraRotateX = 35f;
    public float cameraRotateY = 10f;
    public float showObjectDelay = 2f;

    private float sphereYOffset = -52f;

    private Vector3 targetPosition;
    private CharacterController _controller;
    private GameObject currentCamera;
    private float step;
    private Vector3 offset;
    private AudioSource audioClick;

    private void Awake()
    {
        displayObject.SetActive(false);
        currentCamera = GameObject.FindGameObjectWithTag(currentCameraTag);
        //currentCamera = Camera.current.GetComponent<Camera>();
        _controller = GameObject.FindGameObjectWithTag(slaveObjectTag).GetComponent<CharacterController>();
        //_controller = slaveObject.GetComponent<CharacterController>();
        audioClick = gameObject.GetComponent<AudioSource>();
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
        GlobalState.isPlayerLockedAtRoom1 = true;
        Cursor.lockState = CursorLockMode.None;
        CursorController.instance.hideUICursorImage();
        Cursor.visible = true;
        uiTextPressEscHint.SetActive(true);
        uiTextInstruction.SetActive(true);
        audioClick.Play();

        // Wait for N seconds and show the display object 
        StartCoroutine(ShowObjects(showObjectDelay));
    }

    IEnumerator ShowObjects(float seconds)
    {
        showSpheres();
        yield return new WaitForSeconds(seconds);
        displayObject.SetActive(true);
    }

    private void Update()
    {

        if (GlobalState.isPlayerLockedAtRoom1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GlobalState.isPlayerLockedAtRoom1 = false;
                Cursor.lockState = CursorLockMode.Locked;
                CursorController.instance.showUICursorImage();
                Cursor.visible = false;
                uiTextPressEscHint.SetActive(false);
                uiTextInstruction.SetActive(false);
            }
            targetPosition = masterObject.position;
            currentCamera.transform.rotation = Quaternion.RotateTowards(currentCamera.transform.rotation, Quaternion.Euler(cameraRotateX, cameraRotateY, 0), step);
            offset = targetPosition - _controller.transform.position;

            if (offset.magnitude > .1f)
            {
                _controller.enabled = false;
                _controller.transform.position = Vector3.MoveTowards(_controller.transform.position, targetPosition, step);
                _controller.enabled = true;
            }
        }

    }

    private void showSpheres()
    {
        GameObject[] spheres = GameObject.FindGameObjectsWithTag("Room 1 Spheres");
        foreach (GameObject sphere in spheres)
        {
            Instantiate(sphere, sphere.transform.position + new Vector3(0, sphereYOffset, 0), Quaternion.identity);
        }
    }
}
