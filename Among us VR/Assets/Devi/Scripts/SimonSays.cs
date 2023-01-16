using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    [SerializeField] GameObject[] Tiles;
    [SerializeField] AudioSource[] Sounds;
    BoxCollider box;
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

    public AudioSource Correct,Incorrect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartGame();
        }
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
            if (Sequence[InputInSequence] == ButtonINT)
            {
                InputInSequence++;
                if (InputInSequence >= Sequence.Count)
                {
                    Correct.Play();
                    Debug.Log("Sound");
                    StartCoroutine(WaitBetweenSequences());
                }
            } else {
                Incorrect.Play();
                Debug.Log("INCORRECT AUDIO");
                GameActive = false;
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
        Enable(true);            
        NoiseTimerCounter = NoiseTimer;            
        ShouldBeOn = true;            
        GameActive = false;  
        if (Sequence.Count == 5)
        {
            Debug.Log("Door OPEN");
            Destroy(this.gameObject);
        }                                  
    }
    void Enable(bool state)
    {
        mesh = Tiles[Sequence[PositionInSequence]].GetComponent<MeshRenderer>();
        box = Tiles[Sequence[PositionInSequence]].GetComponent<BoxCollider>();
        if (state == true)
        {
            Sounds[Sequence[PositionInSequence]].Play();
            box.enabled = true;
            mesh.enabled = true;
        } else if (state == false)
        {
            Sounds[Sequence[PositionInSequence]].Stop();
            box.enabled = false;
            mesh.enabled = false;
        }
        
    }
    
}
