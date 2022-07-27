using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonGeneric<PlayerController>
{
    float horizontalInput;
    public int _ballsCollected;

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, transform.position.y, transform.position.z);
        transform.Translate(movement * 1.5f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BallController>())
        {
            _ballsCollected++;
            EventHandler.Instance.InvokeOnBallCollected();
        }
    }
}
