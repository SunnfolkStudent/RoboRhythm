using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(RBossFightSettings))]
[RequireComponent(typeof(AudioSource))]
public class RSongPosition : MonoBehaviour
{
    private RBossFightSettings bossFightSettings;
    
    [Header("Read Only")]
    public float songPosition;
    public float songPosInBeats;
    public  float secPerBeat;
    private float dsptimesong;

    private void Awake()
    {
        bossFightSettings = GetComponent<RBossFightSettings>();
    }

    void Start()
    {
        secPerBeat = 60f / bossFightSettings.songBpm;
        //record the time when the song starts
        dsptimesong = (float) AudioSettings.dspTime;
        GetComponent<AudioSource>().Play();
    }
    
    void Update()
    {
        //calculate the position in seconds
        songPosition = (float) (AudioSettings.dspTime - dsptimesong);

        //calculate the position in beats
        songPosInBeats = songPosition / secPerBeat;
        
    }
}
