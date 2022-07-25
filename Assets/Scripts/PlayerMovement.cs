using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, transform.position.y, transform.position.z);
        //movement.Normalize();
        transform.Translate(movement * 1.5f * Time.deltaTime);
    }
}
