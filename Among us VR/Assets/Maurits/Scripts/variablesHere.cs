using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variablesHere : MonoBehaviour
{
    public float playerHeight;
    public float armSpan;
    public GameObject Calc;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetVar());
    }

    // Update is called once per frame
    IEnumerator GetVar()
    {
        yield return new WaitForSeconds(5);
        playerHeight = Calc.GetComponent<HeightCal>().playerHeight;
        armSpan = Calc.GetComponent<HeightCal>().armLength;
    }
}
