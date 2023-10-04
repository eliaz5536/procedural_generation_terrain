using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTitleScreen : MonoBehaviour
{
    public float speed = 0.05f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
    }
}
