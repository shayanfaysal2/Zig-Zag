using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int index;

    void Fall()
    {
        //Only fall if not first cube
        if (index > 0 && GetComponent<Rigidbody>() == null)
            gameObject.AddComponent<Rigidbody>();

        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 1);
            LevelGenerator.instance.GenerateCube();
        }
    }
}
