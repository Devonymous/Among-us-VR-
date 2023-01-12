using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePlayParticleEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem Effect;

    public void PlayEffect()
    {
        Effect.Play();
    }

}
