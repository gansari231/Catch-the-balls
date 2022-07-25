using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.down * 1.5f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
