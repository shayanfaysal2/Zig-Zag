using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwitchDirection();
        }

        if (GameManager.instance.isGameStarted)
        {
            rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, transform.forward.z * speed);

            if (transform.position.y < -5f)
                GameManager.instance.GameOver();
        }
    }

    public void SwitchDirection()
    {
        if (transform.forward == Vector3.forward)
        {
            transform.forward = Vector3.right;
        }
        else
        {
            transform.forward = Vector3.forward;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            GameManager.instance.CollectDiamond();
            Destroy(other.gameObject);
        }
    }
}
