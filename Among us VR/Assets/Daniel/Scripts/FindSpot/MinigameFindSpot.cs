using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFindSpot : MinigameBase
{

    [SerializeField] GameObject spotTrigger;
    [SerializeField] GameObject PlayingField;
    [SerializeField] float PlayingFieldRangeX;
    [SerializeField] float PlayingFieldRangeY;
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

    void Init()
    {
        Vector3 offset = PlayingField.transform.rotation * new Vector3(Random.Range(PlayingFieldRangeX, -PlayingFieldRangeX), 0, Random.Range(PlayingFieldRangeY, -PlayingFieldRangeY));
        spotTrigger.transform.rotation = PlayingField.transform.rotation;
        spotTrigger.transform.position = PlayingField.transform.position + offset;
    }

}
