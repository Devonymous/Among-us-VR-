using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class testy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OntriggerStay(Collider other)
    {
     if (other.tag == "Player")
     {
        Debug.Log("PLEASE");
     }
    }
}
