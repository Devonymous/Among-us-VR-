using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public Transform Front;

    public Transform Back;

    public void SetDoorState(bool Open)
    {
        animator.SetBool("Open", Open);
    }

    public void MovetoDoor(GameObject PlayerObj)
    {
        PlayerObj.transform.position = transform.position;
    }

}
