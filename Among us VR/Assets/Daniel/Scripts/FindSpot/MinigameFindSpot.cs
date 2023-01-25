using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFindSpot : MinigameBase
{

    [SerializeField] GameObject spotTrigger;
    [SerializeField] GameObject PlayingField;
    float PlayingFieldRangeX;
    float PlayingFieldRangeZ;
    [SerializeField] int TimesToComplete;


    int CurrentScore;


    // Start is called before the first frame update
    void OnEnable()
    {
        Init();
    }
    
   
    public void RoundComplete()
    {
        if(CurrentScore >= TimesToComplete)
        {
            OnComplete.Invoke();
        }else
        {
            CurrentScore++;
            Init();
        }
    }

    public void DisableMinigame()
    {
        Destroy(transform.parent.gameObject);
    }

    void Init()
    {
        PlayingFieldRangeX = PlayingField.transform.lossyScale.x / 2;
        PlayingFieldRangeZ = PlayingField.transform.lossyScale.z / 2;
        Vector3 offset = PlayingField.transform.rotation * new Vector3(Random.Range(PlayingFieldRangeX, -PlayingFieldRangeX), 0, Random.Range(PlayingFieldRangeZ, -PlayingFieldRangeZ));
        spotTrigger.transform.rotation = PlayingField.transform.rotation;
        spotTrigger.transform.position = PlayingField.transform.position + offset;
    }

}
