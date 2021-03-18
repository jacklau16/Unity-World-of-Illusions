using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    private Vector3 _velocity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // Handle Gravity
        if (!GlobalState.IsPlayerLockedAtAnyRoom())
        {
            if (controller.isGrounded)
                _velocity.y = 0f;
            else
            {
                _velocity.y += Physics.gravity.y * Time.deltaTime;
                controller.Move(_velocity * Time.deltaTime);
            }

        }
        else
        {
            _velocity.y = 0f;
        }

    }
}
