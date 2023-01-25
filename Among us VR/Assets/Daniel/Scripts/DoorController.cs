using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] GameObject Minigame;

    public Transform Front;

    public Transform Back;

   [SerializeField] Transform RoomFront;

   [SerializeField] Transform RoomBack;

    Transform Destination;

    GameObject player;

    bool Locked = true;

    public void SetDoorState(bool Open)
    {
        animator.SetBool("Open", Open);
        Locked = !Open;
    }

    public void MovetoDoor(GameObject PlayerObj)
    {
        PlayerObj.GetComponent<PlayerLocationManager>().Idle = false;
        player = PlayerObj;
        if (Vector3.Distance(PlayerObj.transform.position, Front.position) < Vector3.Distance(PlayerObj.transform.position, Back.position))
        {
            PlayerObj.transform.position = Front.position;
            Destination = RoomBack;
        }else
        {
            PlayerObj.transform.position = Back.position;
            Destination = RoomFront;
        }

        if (Locked && Minigame)
        {
            Minigame.SetActive(true);
        }else
        {
            MovetoDestinationDelay();
            SetDoorState(true);
        }

    }

    public void MovetoDestinationDelay()
    {
        Invoke("MoveToDestination", 2);
    }

    void MoveToDestination()
    {
        player.transform.position = Destination.position;
        player.GetComponent<PlayerLocationManager>().Idle = true;
    }

}
