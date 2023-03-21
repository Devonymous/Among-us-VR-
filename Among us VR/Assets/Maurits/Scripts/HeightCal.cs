using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCal : MonoBehaviour
{
    /*** why calculate with player height with armspan when you can just look at how high the camera goes >.>
    
    public GameObject LController;
    public GameObject RController;

    public Vector3 L1;
    public Vector3 L2;
    public Vector3 L3;
    public Vector3 R1;
    public Vector3 R2;
    public Vector3 R3;
    public Vector3 Tot;

    public bool calHeight = false;

    ***/

    public GameObject myself;
    public GameObject heightCam;
    public Vector3 playerVector;
    public float playerHeight;
    public float armLength;

    private void Start()
    {
        StartCoroutine(CalHeight());
    }

    IEnumerator CalHeight()
    {
        yield return new WaitForSeconds(2);
        playerVector = heightCam.transform.position;
        playerHeight = playerVector.y;
        armLength = playerVector.y / 2; //calculates center of body to hand, not actual arm length.
        Debug.Log("Player Height: " + playerHeight + " | Arm Length: " + armLength);
        yield return new WaitForSeconds(4);
        myself.SetActive(false);
    }

    /*** why calculate with player height with armspan when you can just look at how high the camera goes >.>
    
    private void Update()
    {
        if(calHeight == false) {
            StartCoroutine(calculateHeight());
        }
    }

    IEnumerator calculateHeight()
    {
        calHeight = true;
        L1 = LController.transform.position;
        R1 = RController.transform.position;
        yield return new WaitForSeconds(1);

        L2 = LController.transform.position;
        R2 = RController.transform.position;
        yield return new WaitForSeconds(1);

        L3 = LController.transform.position;
        R3 = RController.transform.position;
        yield return new WaitForSeconds(1);

        L1 = (L1 + L2 + L3) / 3;
        R1 = (R1 + R2 + R3) / 3;

        Tot = R1 - L1;
        Debug.Log(Tot.x);
    }

    ***/
}
