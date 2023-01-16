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
    }

    public void ActivateIndicator()
    {
        InvokeRepeating("CheckPlayerDistance", 0, 3);
    }

    void CheckPlayerDistance()
    {
        if (Vector3.Distance(transform.position, ControllerL.transform.position) < 1f)
        {
            //send strong pulses to indacate the player is very near
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) < 3f)
        {
            //send medium pulses that indicates the player is getting closer
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) < 6f)
        {
            //send weak pulses that indicates the player is far away
        }
    }

}

//viveController.SendImpulse(amplitude, duration);
