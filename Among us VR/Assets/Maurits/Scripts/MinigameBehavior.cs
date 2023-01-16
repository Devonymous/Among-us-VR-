using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBehavior : MonoBehaviour
{
    public static int completed = 0;
    public GameObject objUp;
    public GameObject objLeft;
    public GameObject objRight;

    int timer = 540;

    int goalOneL;
    int goalTwoL;
    int goalThreeL;
    int goalOneR;
    int goalTwoR;
    int goalThreeR;

    public GameObject[] directions;

    // Start is called before the first frame update
    void Start()
    {
        goalOneL = Random.Range(0, 2);
        goalTwoL = Random.Range(0, 2);
        goalThreeL = Random.Range(0, 2);
        goalOneR = Random.Range(3, 5);
        goalTwoR = Random.Range(3, 5);
        goalThreeR = Random.Range(3, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer >= 600) {
            if (completed == 0) {
                directions[goalOneL].SetActive(true);
                directions[goalOneR].SetActive(true);
            }
    
            if (completed == 1)
            {
                directions[goalTwoL].SetActive(true);
                directions[goalTwoR].SetActive(true);
            }
            
            if (completed == 2)
            {
                directions[goalThreeL].SetActive(true);
                directions[goalThreeR].SetActive(true);
            }
            
            //ends the minigame
            if (completed == 3)
            {
                gameObject.SetActive(false);
            }
            timer = 0;
        }
        else
        {
            timer++;
        }
    }
}
