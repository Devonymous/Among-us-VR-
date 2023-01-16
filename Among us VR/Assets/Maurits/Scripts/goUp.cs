using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goUp : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        // Moves an object forward, relative to its own rotation.
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
