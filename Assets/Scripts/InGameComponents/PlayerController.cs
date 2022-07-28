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

    void LateUpdate()
    {
        SetPlayerBounds();
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
            AudioManager.Instance.PlayCollectableSound();
            _ballsCollected++;
            EventHandler.Instance.InvokeOnBallCollected();
        }
    }

    void SetPlayerBounds()
    {
        if (transform.position.x >= 2.5f)
        {
            transform.position = new Vector3(2.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -2.5f)
        {
            transform.position = new Vector3(-2.5f, transform.position.y, 0);
        }
    }
}
