using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool onbutton = false;
    BoxCollider box;
    MeshRenderer mesh;
    private SimonSays Script;
    public int ThisbuttonNumber;
    private AudioSource Sound;

    void Start()
    {
        Script = FindObjectOfType<SimonSays>();
        mesh = GetComponent<MeshRenderer>();
        box = GetComponent<BoxCollider>();
        Sound = GetComponent<AudioSource>();
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
            Sound.Play(); // PLAY SOUND
        }
        if (Input.GetKeyUp(KeyCode.P) && onbutton == true && Script.GameActive == true)
        {
            Sound.Stop(); // PLAY SOUND
            Enable(false);
            onbutton = false;
            Script.ButtonPressed(ThisbuttonNumber);
        }
    }

    void OntriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onbutton = true;
        }
    }
    void OntriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onbutton = false;
        }
    }

    void Enable(bool state)
    {
        if (state == true)
        {
            box.enabled = true;
            mesh.enabled = true;
        } else if (state == false)
        {
            box.enabled = false;
            mesh.enabled = false;
        }
        
    }
}
