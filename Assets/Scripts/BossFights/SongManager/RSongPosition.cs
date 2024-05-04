using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RBossFightSettings))]
[RequireComponent(typeof(AudioSource))]
public class RSongPosition : MonoBehaviour
{
    private RBossFightSettings bossFightSettings;
    
    [Header("Read Only")]
    public float songPosition;
    public float songPosInBeats;
    public  float secPerBeat;
    public float dsptimesong;
    public float skipTime;

    private bool _songStarted;

    private AudioSource _audioSource;

    private void Awake()
    {
        bossFightSettings = GetComponent<RBossFightSettings>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        AudioManager.instance.StopMusic();
        _audioSource.Play();
        secPerBeat = 60f / bossFightSettings.songBpm;
        dsptimesong = (float) AudioSettings.dspTime;
        _songStarted = true;
    }
    
    void Update()
    {
        if(!_songStarted) return;
        //calculate the position in seconds
        songPosition = (float) (AudioSettings.dspTime - dsptimesong + skipTime);

        //calculate the position in beatse
        songPosInBeats = (songPosition / secPerBeat) + 1;
        
    }
}
