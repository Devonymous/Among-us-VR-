using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] MinigameBase minigame;

    void OnTriggerEnter(Collider other)
    {
        minigame.OnComplete.Invoke();
    }
}
