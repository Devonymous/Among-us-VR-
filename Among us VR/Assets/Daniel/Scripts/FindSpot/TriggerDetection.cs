using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using FMODUnity;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] MinigameBase minigame;

    [SerializeField] GameObject ControllerL;
    [SerializeField] GameObject ControllerR;

    [SerializeField] bool UseLegacyHaptics = false;

    [SerializeField]  StudioEventEmitter Beep;


    public SteamVR_Action_Vibration HapticAction;

    float HapticStrengthL = 0.5f;
    float HapticStrengthR = 0.5f;
    float HapticCooldownL;
    float HapticCooldownR;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left" || other.tag == "Right")
        {
            minigame.OnCompleteRound.Invoke();

            //send strongest pulse to indicate that the player reached the spot
            HapticAction.Execute(0, 1, 150, 1, SteamVR_Input_Sources.LeftHand);
            HapticAction.Execute(0, 1, 150, 1, SteamVR_Input_Sources.RightHand);
        }
    }

    void Start()
    {
        ActivateIndicator();
    }

    public void ActivateIndicator()
    {
        InvokeRepeating("AudioCue", 0, 5);

        if (UseLegacyHaptics)
        InvokeRepeating("CheckPlayerDistance", 0, 1);
    }

    public void AudioCue()
    {
        Beep.Play();
        Debug.Log("beep");
    }

    void Update()
    {
        if (!UseLegacyHaptics)
        {
            float ProgressL = Mathf.InverseLerp(4, 0, Vector3.Distance(transform.position, ControllerL.transform.position));
            HapticStrengthL = ProgressL;
            if (HapticCooldownL < Time.time)
            {
                HapticFeedbackLeft();
                HapticCooldownL = Time.time + ((1 - ProgressL) * 1.1f);
            }

            float ProgressR = Mathf.InverseLerp(4, 0, Vector3.Distance(transform.position, ControllerR.transform.position));
            HapticStrengthR = ProgressR;
            if (HapticCooldownR < Time.time)
            {
                HapticFeedbackRight();
                HapticCooldownR = Time.time + ((1 - ProgressR) * 1.1f);
            }
        }
    }

    void HapticFeedbackLeft()
    {
        HapticAction.Execute(0, 0.1f, 150, HapticStrengthL, SteamVR_Input_Sources.LeftHand);
    }

    void HapticFeedbackRight()
    {
        HapticAction.Execute(0, 0.1f, 150, HapticStrengthR, SteamVR_Input_Sources.RightHand);
    }

    //Legacy
    void CheckPlayerDistance()
    {
        //LEFT
        if (Vector3.Distance(transform.position, ControllerL.transform.position) < 0.4f)
        {
            //send strong pulses to indacate the player is very near
            Debug.Log("Very near");
            HapticAction.Execute(0, 0.2f, 150, 0.6f, SteamVR_Input_Sources.LeftHand);
        }
        else if (Vector3.Distance(transform.position, ControllerL.transform.position) < 1)
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
        if (Vector3.Distance(transform.position, ControllerR.transform.position) < 0.4f)
        {
            //send strong pulses to indacate the player is very near
            Debug.Log("Very near");
            HapticAction.Execute(0, 0.2f, 150, 0.6f, SteamVR_Input_Sources.RightHand);
        }
        else if (Vector3.Distance(transform.position, ControllerR.transform.position) < 1)
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
