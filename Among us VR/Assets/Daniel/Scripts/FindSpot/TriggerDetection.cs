using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] MinigameBase minigame;

    [SerializeField] GameObject ControllerL;
    [SerializeField] GameObject ControllerR;

    public SteamVR_Action_Vibration HapticAction;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller")
        {
            minigame.OnCompleteRound.Invoke();

            //send strongest pulse to indicate that the player reached the spot
            HapticAction.Execute(0, 1, 150, 1, SteamVR_Input_Sources.LeftHand);
        }
    }

    void Start()
    {
        ActivateIndicator();
    }

    public void ActivateIndicator()
    {
        InvokeRepeating("CheckPlayerDistance", 0, 1);
    }

    void CheckPlayerDistance()
    {
        //LEFT
        if (Vector3.Distance(transform.position, ControllerL.transform.position) < 0.2f)
        {
            //send strong pulses to indacate the player is very near
            Debug.Log("Very near");
            HapticAction.Execute(0, 0.2f, 150, 0.6f, SteamVR_Input_Sources.LeftHand);
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) < 0.5f)
        {
            //send medium pulses that indicates the player is getting closer
            Debug.Log("Near");
            HapticAction.Execute(0, 0.2f, 150, 0.3f, SteamVR_Input_Sources.LeftHand);
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) > 1)
        {
            //send weak pulses that indicates the player is far away
            Debug.Log("far away");
            HapticAction.Execute(0, 0.2f, 150, 0.1f, SteamVR_Input_Sources.LeftHand);
        }

        //RIGHT
        if (Vector3.Distance(transform.position, ControllerR.transform.position) < 0.2f)
        {
            //send strong pulses to indacate the player is very near
            Debug.Log("Very near");
            HapticAction.Execute(0, 0.2f, 150, 0.6f, SteamVR_Input_Sources.RightHand);
        }
        else if (Vector3.Distance(transform.position, ControllerR.transform.position) < 0.5f)
        {
            //send medium pulses that indicates the player is getting closer
            Debug.Log("Near");
            HapticAction.Execute(0, 0.2f, 150, 0.3f, SteamVR_Input_Sources.RightHand);
        }
        else if (Vector3.Distance(transform.position, ControllerR.transform.position) > 1)
        {
            //send weak pulses that indicates the player is far away
            Debug.Log("far away");
            HapticAction.Execute(0, 0.2f, 150, 0.1f, SteamVR_Input_Sources.RightHand);
        }
    }

}

//viveController.SendImpulse(amplitude, duration);
