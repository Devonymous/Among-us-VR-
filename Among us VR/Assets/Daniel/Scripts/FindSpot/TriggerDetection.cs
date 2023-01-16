using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] MinigameBase minigame;

    [SerializeField] GameObject ControllerL;
    [SerializeField] GameObject ControllerR;


    void OnTriggerEnter(Collider other)
    {
        minigame.OnCompleteRound.Invoke();

        //send strongest pulse to indicate that the player reached the spot
        SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 1, 10, 1);
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
        if (Vector3.Distance(transform.position, ControllerL.transform.position) < 2f)
        {
            //send strong pulses to indacate the player is very near
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 10, 0.6f);
            Debug.Log("Very near");
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) < 6f)
        {
            //send medium pulses that indicates the player is getting closer
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 10, 0.3f);
            Debug.Log("Near");
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) > 6f)
        {
            //send weak pulses that indicates the player is far away
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 10, 0.1f);
            Debug.Log("far away");
        }
    }

}

//viveController.SendImpulse(amplitude, duration);
