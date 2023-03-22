using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMinigame : MonoBehaviour
{
    [SerializeField] private GameObject minigame;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(waitAndActivate());
    }

    // Update is called once per frame
    IEnumerator waitAndActivate()
    {
        yield return new WaitForSecondsRealtime(16);
        minigame.SetActive(true);
    }
}
