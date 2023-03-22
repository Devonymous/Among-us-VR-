using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxLeft : MonoBehaviour
{
    public static int readyL;
    public GameObject complete;
    // Start is called before the first frame update
    void Start()
    {
        readyL = 0;
    }

    void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag == "Left")
        {
            readyL = 1;
            if (hitboxRight.readyR == 1 && readyL == 1)
            {
                readyL = 0;
                hitboxRight.readyR = 0;
                complete.SetActive(true);
                complete.SetActive(false);
                MinigameBehavior.timer = 480;
                gameObject.SetActive(false);
                Debug.Log("Hello");
                MinigameBehavior.completed++;
            }
        }
    }
}
