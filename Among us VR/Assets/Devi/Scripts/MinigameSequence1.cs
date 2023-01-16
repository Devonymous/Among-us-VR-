using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSequence1 : MinigameBase
{
    [SerializeField] List<string> SequenceOptions;
    [SerializeField]List<string> Sequence;

    [SerializeField] int SequenceLength;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < SequenceLength; i++)
        {
            Sequence.Add(SequenceOptions[Random.Range(0, SequenceOptions.Count)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
