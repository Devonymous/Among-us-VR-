using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxLeft : MonoBehaviour
{
    public static int readyL;
    // Start is called before the first frame update
    void Start()
    {
        readyL = 0;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Left")
        {
            readyL = 1;
            if (hitboxRight.readyR == 1) {
                MinigameBehavior.completed++;
                gameObject.SetActive(false);
                Debug.Log("Hello");
            }
        }
    }
}
