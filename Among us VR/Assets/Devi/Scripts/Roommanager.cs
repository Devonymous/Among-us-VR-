using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roommanager : MonoBehaviour
{

    public Triggercords trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Boop)
    {
        if (Boop.tag == "Right" || Boop.tag == "Left")
        {
            Debug.Log("HIT");
            trigger = Boop.gameObject.GetComponent<Triggercords>();
            this.transform.position = trigger.Cords.transform.position;
            Debug.Log(trigger.Cords.transform.position);
        }
    }

    void OnTriggerExit(Collider Boop)
    {
        if (Boop.tag == "Right" || Boop.tag == "Left")
        {
            Debug.Log("pos cleared");
            trigger = null;
        }
    }
}
