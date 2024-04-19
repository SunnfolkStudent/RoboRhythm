using System;
using UnityEngine;
using TMPro;

public class REffectsManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void NoteHitEffects(int audioSourceNumber)
    {
        audioSource.PlayOneShot(audioClips[audioSourceNumber]);
    }
}
