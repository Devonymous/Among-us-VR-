using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public Transform Front;

    public Transform Back;

    bool Locked = true;

    public void SetDoorState(bool Open)
    {
        animator.SetBool("Open", Open);
        Locked = !Open;
    }

    public void MovetoDoor(GameObject PlayerObj)
    {
        if (Vector3.Distance(PlayerObj.transform.position, Front.position) < Vector3.Distance(PlayerObj.transform.position, Back.position))
        {
            PlayerObj.transform.position = Front.position;
        }else
        {
            PlayerObj.transform.position = Back.position;
        }
    }

}
