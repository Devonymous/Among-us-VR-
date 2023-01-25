using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxRight : MonoBehaviour
{
    public static int readyR;
    // Start is called before the first frame update
    void Start()
    {
        readyR = 0;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag == "Right")
        {
            readyR = 1;
        }
    }
}
