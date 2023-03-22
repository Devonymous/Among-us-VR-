using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using FMODUnity;

public class ButtonController : MonoBehaviour
{
    public bool onbutton = false;
    MeshRenderer mesh;
    private SimonSays Script;
    public int ThisbuttonNumber;
    bool buttoncheck = false;

    public GameObject sound; 
    public float distanceleft,distanceright; 
    public GameObject Left,Right;
    public SteamVR_Action_Boolean backButton;
    public SteamVR_Action_Vibration HapticAction;
    void Start()
    {
        Script = FindObjectOfType<SimonSays>();
        mesh = GetComponent<MeshRenderer>();
        HapticAction = SteamVR_Actions._default.Haptic;
        Enable(false);
    }

    // Update is called once per frame
    void Update()
    {
        distanceleft = Vector3.Distance(Left.transform.position,this.transform.position);
        distanceright = Vector3.Distance(Right.transform.position,this.transform.position);
        if (distanceleft < 1.35)
        {
            onbutton = true;
            HapticAction.Execute(0, 0, 150, 0.5f, SteamVR_Input_Sources.LeftHand);
        } else if (distanceright < 1.35)
        {
            onbutton = true;
            HapticAction.Execute(0, 0, 150, .5f, SteamVR_Input_Sources.RightHand);
        } else {
            onbutton = false;
        }
        
        // Button pressed 
        if (backButton.GetStateDown(SteamVR_Input_Sources.Any) == true)
        {
            if (onbutton == true && Script.GameActive == true)
            {
                Enable(true);
                buttoncheck = true;
            }
        }
        if (backButton.GetStateUp(SteamVR_Input_Sources.Any) == true && buttoncheck == true)
        {
                Enable(false);
                onbutton = false;
                Script.ButtonPressed(ThisbuttonNumber);
                buttoncheck = false;
        }
    }


    void Enable(bool state)
    {
        if (state == true)
        {
            sound.SetActive(true);
            mesh.enabled = true;
        } else if (state == false)
        {
            sound.SetActive(false);
            mesh.enabled = false;
        }
        
    }
}
