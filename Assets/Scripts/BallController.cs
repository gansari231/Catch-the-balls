using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    GameObject _explosion;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.down * 1.5f * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            UIManager.Instance.UpdateScore(this.gameObject);
            Instantiate(_explosion, transform.position, _explosion.transform.rotation);
        }
    }
}
