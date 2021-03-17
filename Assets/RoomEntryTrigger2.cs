using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryTrigger2 : MonoBehaviour
{
    public Transform masterObject;
    public Transform slaveObject;
    public GameObject displayObject;
    public Camera currentCamera;
    public float speed = 14f;
    public float cameraRotateX = 27f;
    public float cameraRotateY = 0f;


    private Vector3 wantedPosition = new Vector3(0, 0, 0);
    private Vector3 targetPosition;
    private Vector2 origPosition;
    private CharacterController _controller;
    private Vector3 _velocity;
    private Vector3 offset;
    private float step;


    private void Awake()
    {
        displayObject.SetActive(false);
        //currentCamera = Camera.current.GetComponent<Camera>();
        _controller = slaveObject.GetComponent<CharacterController>();
        step = speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Disable the trigger after its first time use
        BoxCollider bc = gameObject.GetComponent<BoxCollider>();
        //bc.isTrigger = false;
        bc.enabled = false;

        origPosition = slaveObject.position;
        targetPosition = masterObject.position;
        //targetPosition = masterObject.TransformPoint(wantedPosition);

        //slaveObject.position = relativePosition;

        //--------
        offset = slaveObject.position - masterObject.position;

        //Debug.Log("RoomEntryTrigger: Target Position" + targetPosition);
        GlobalState.isPlayerLockedAtRoom2 = true;
        Cursor.lockState = CursorLockMode.None;
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
        //Debug.Log("isPlayerLockedRoom_2: " + GlobalState.isPlayerLockedAtRoom2);
        if (GlobalState.isPlayerLockedAtRoom2)
        {
            _velocity.y = 0f;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("ESC pressed!");
                GlobalState.isPlayerLockedAtRoom2 = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

            currentCamera.transform.rotation = Quaternion.RotateTowards(currentCamera.transform.rotation, Quaternion.Euler(cameraRotateX, cameraRotateY, 0), step); ;
            // working: currentCamera.transform.rotation = Quaternion.Euler(30, 10, 0);
            _controller.enabled = false;
            _controller.transform.position = Vector3.MoveTowards(_controller.transform.position, targetPosition, step);
            //_controller.transform.position = Vector3.Lerp(_controller.transform.position, targetPosition, step);
            _controller.enabled = true;
        }
        if (!GlobalState.IsPlayerLockedAtAnyRoom())
        {
            //Debug.Log("GRAVITY!");
            //Debug.Log("Current Pos: " + _controller.transform.position + ", Target Pos: " + masterObject.position);
            // Enable the gravity effect
            if (_controller.isGrounded)
                _velocity.y = 0f;

            _velocity.y += Physics.gravity.y * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);

        }

    }
}
