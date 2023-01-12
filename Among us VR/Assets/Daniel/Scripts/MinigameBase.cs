using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameBase : MonoBehaviour
{
    public UnityEvent OnComplete;
    public UnityEvent OnCompleteRound;
    public UnityEvent OnFail;
    public UnityEvent OnFailRound;

}
