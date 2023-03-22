using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using FMODUnity;

public class Startingsound : MonoBehaviour
{
    bool phase1 = false,phase2 = false;
    public SphereCollider door;
    [SerializeField] GameObject[] HelpSounds;
    public SteamVR_Action_Boolean backButton;
    public void Start()
    {
        StartCoroutine(StartSound());
    }
    public void Update()
    {
        if (backButton.GetStateDown(SteamVR_Input_Sources.Any) == true && phase1 == true)
        {
            StartCoroutine(SecondSound());
            phase1 = false;
            
        }
    }

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(1);
        HelpSounds[0].SetActive(true);
        yield return new WaitForSeconds(6);
        phase1 = true;
        HelpSounds[0].SetActive(false);
    }
    IEnumerator SecondSound()
    {
        HelpSounds[1].SetActive(true);
        yield return new WaitForSeconds(14);
        phase2 = true;
        door.enabled = true;
        HelpSounds[1].SetActive(false);
    }
}
