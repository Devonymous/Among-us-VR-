using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using FMODUnity;

public class ButtonController : MonoBehaviour
{
    public bool onbutton = false;
    BoxCollider box;
    MeshRenderer mesh;
    private SimonSays Script;
    public int ThisbuttonNumber;

    public GameObject sound; 

    void Start()
    {
        Script = FindObjectOfType<SimonSays>();
        mesh = GetComponent<MeshRenderer>();
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Temp Input that acts as hands
        if (Input.GetKeyDown(KeyCode.T))
        {
            onbutton = true;
        }
        // Button pressed 
        if (Input.GetKeyDown(KeyCode.P) && onbutton == true && Script.GameActive == true)
        {
            Enable(true);
        }
        if (Input.GetKeyUp(KeyCode.P) && onbutton == true && Script.GameActive == true)
        {
            Enable(false);
            onbutton = false;
            Script.ButtonPressed(ThisbuttonNumber);
        }
    }

    void OntriggerStay(Collider other)
    {
        Debug.Log("HIT");
        if (other.tag == "Controller")
        {
            onbutton = true;
        }
    }
    void OntriggerExit(Collider other)
    {
        if (other.tag == "Controller")
        {
            onbutton = false;
        }
    }

    void Enable(bool state)
    {
        if (state == true)
        {
            sound.SetActive(true);
            box.enabled = true;
            mesh.enabled = true;
        } else if (state == false)
        {
            sound.SetActive(false);
            box.enabled = false;
            mesh.enabled = false;
        }
        
    }
}
