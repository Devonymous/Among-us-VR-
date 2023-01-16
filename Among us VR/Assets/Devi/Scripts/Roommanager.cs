using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Roommanager : MonoBehaviour
{

    public Triggercords trigger;
    public GameObject pref;
    public GameObject text; 
    bool enter = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter == true && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(pref,trigger.Cords.transform.position,Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider Boop)
    { 
        if (Boop.tag == "Right" || Boop.tag == "Left")
        {
            enter = true;
            text.gameObject.SetActive(true);
            trigger = Boop.gameObject.GetComponent<Triggercords>();
            pref = trigger.prefab;
        }
    }

    void OnTriggerExit(Collider Boop)
    {
        if (Boop.tag == "Right" || Boop.tag == "Left")
        {
            enter = false;
            text.gameObject.SetActive(false);
            trigger = null;
        }
    }
}
