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
            Debug.Log("Very near");
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 10, 0.6f);
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) < 6f)
        {
            //send medium pulses that indicates the player is getting closer
            Debug.Log("Near");
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 10, 0.3f);
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) > 6f)
        {
            //send weak pulses that indicates the player is far away
            Debug.Log("far away");
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 10, 0.1f);
        }
    }

}

//viveController.SendImpulse(amplitude, duration);
