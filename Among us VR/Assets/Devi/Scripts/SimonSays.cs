using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    [SerializeField] GameObject[] Tiles;
    [SerializeField] GameObject[] sound;
    [SerializeField] GameObject[] HelpSounds;
    [SerializeField] DoorController script;
    MeshRenderer mesh;
    private int Select;
    public float NoiseTimer;
    private  float NoiseTimerCounter;
    public float WaitBetweenLights;
    private float WaitBetweenCounter;
    private bool ShouldBeOn,ShouldBeOff;
    public bool GameActive = false;
    private int InputInSequence;

    public List<int> Sequence;
    private int PositionInSequence;

    public GameObject Correct,Incorrect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    void Update()
    {
        if (ShouldBeOn)
        {
            NoiseTimerCounter -= Time.deltaTime;
            if (NoiseTimerCounter < 0)
            {
                Enable(false);
                ShouldBeOn = false;

                ShouldBeOff = true;
                WaitBetweenCounter = WaitBetweenLights;

                PositionInSequence++;
            }
        } 
        if (ShouldBeOff)
        {
            WaitBetweenCounter -= Time.deltaTime;

            if(PositionInSequence >= Sequence.Count)
            {
                ShouldBeOff = false;
                GameActive = true;
            } else {
                if (WaitBetweenCounter < 0)
                {
                    Enable(true);
                    NoiseTimerCounter = NoiseTimer;
                    ShouldBeOn = true;
                    ShouldBeOff = false;
                }
            }
        }
           
    }

    IEnumerator waiter()
    {
        for (int i = 0; i > 3; i ++)
        {
            Tiles[i].SetActive(false);
        }
        yield return new WaitForSecondsRealtime(1);
        HelpSounds[0].SetActive(true);
        yield return new WaitForSecondsRealtime(27);
        HelpSounds[0].SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        for (int i = 0; i > 3; i++)
        {
            Tiles[i].SetActive(true);
        }
        StartGame();
    }
    public void StartGame()
    {
        Sequence.Clear();
        PositionInSequence = 0;
        InputInSequence = 0;
        Select = Random.Range(0, Tiles.Length);
        Sequence.Add(Select);
        Enable(true);
        NoiseTimerCounter = NoiseTimer;
        ShouldBeOn = true;
    }

    public void ButtonPressed(int ButtonINT)
    {
        if (GameActive)
        {
            Debug.Log("test");
            if (Sequence[InputInSequence] == ButtonINT)
            {
                InputInSequence++;
                Correct.SetActive(false);
                if (InputInSequence >= Sequence.Count)
                {
                    Correct.SetActive(true);
                    StartCoroutine(WaitBetweenSequences());
                }
            } else {
                Incorrect.SetActive(true);
                Invoke("StartGame",3f);
            }
        }
        
    }

    IEnumerator WaitBetweenSequences()
    {
        yield return new WaitForSeconds(1.3f);

        PositionInSequence = 0;
        InputInSequence = 0;
        Select = Random.Range(0, Tiles.Length);
        Sequence.Add(Select);            
        Incorrect.SetActive(false);
        Enable(true);            
        NoiseTimerCounter = NoiseTimer;            
        ShouldBeOn = true;            
        GameActive = false;  
        if (Sequence.Count == 5)
        {
            script.SetDoorState(true);
            script.MovetoDestinationDelay();
            this.gameObject.SetActive(false);
        }                                  
    }
    void Enable(bool state)
    {
        mesh = Tiles[Sequence[PositionInSequence]].GetComponent<MeshRenderer>();
        if (state == true)
        {
            sound[Sequence[PositionInSequence]].SetActive(true);
            mesh.enabled = true;
        } else if (state == false)
        {
            sound[Sequence[PositionInSequence]].SetActive(false);
            mesh.enabled = false;
        }
        
    }
    
}
