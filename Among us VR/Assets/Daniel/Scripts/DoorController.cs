using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void SetDoorState(bool Open)
    {
        animator.SetBool("Open", Open);
    }

}
