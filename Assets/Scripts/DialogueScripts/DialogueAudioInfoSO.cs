using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueAudioInfo", menuName = 
    "ScriptableObjects/DialogueAudioInfoSO", order = 1)]
public class DialogueAudioInfoSO : ScriptableObject
{
    public string id;
    
    public AudioClip[] dialogueTypingSoundClips;
    [Range(1, 5)]
    public int frequencyLevel = 2;
    [Range(-5, 1)]
    public float minPitch = 0.5f;
    [Range(-5, 1)]
    public float maxPitch = 3f;
    public bool stopAudioSource;
}
