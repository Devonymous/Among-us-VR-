using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionGoal : MonoBehaviour
{
    public GameObject activateDirection;

    // Start is called before the first frame update
    void OnEnable()
    {
        activateDirection.SetActive(true);
        gameObject.SetActive(false);
    }
}
