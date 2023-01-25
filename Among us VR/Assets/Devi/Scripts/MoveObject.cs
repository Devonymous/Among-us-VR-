using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
    }
}
