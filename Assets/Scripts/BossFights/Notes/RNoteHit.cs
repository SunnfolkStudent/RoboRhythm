using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(RProjectileMovement))]
public class RNoteHit : MonoBehaviour
{
    [SerializeField] private int soundClipNumber;
    [Header("Best To Worst Range")]
    [SerializeField] private RRangeInformation[] rRangeInformation;
    
    private RProjectileMovement projectileMovement;
    private RScoreManager scoreManager;
    private RSoundEffectsManager _soundEffectsManager;
    
    private void Start()
    {
        projectileMovement = GetComponent<RProjectileMovement>();
        scoreManager = FindObjectOfType<RScoreManager>();
        _soundEffectsManager = FindObjectOfType<RSoundEffectsManager>();
    }

    private void Update()
    {
        if(!Input.GetKeyDown(KeyCode.Space)) {return;}
        var noteLocation = projectileMovement.timeVariable + projectileMovement.timeVariable1;
        for (int i = 0; i < rRangeInformation.Length; i++)
        {
            if (noteLocation > rRangeInformation[i].lowerRange && noteLocation < rRangeInformation[i].upperRange)
            {
                var rangeInfo = rRangeInformation[i];
                Debug.Log(rangeInfo.scoreText);
                scoreManager.NoteHit(rangeInfo.noteWorth,rangeInfo.scoreText,rangeInfo.textColor,rangeInfo.perfectHit);
                _soundEffectsManager.HitSoundEffect(soundClipNumber);
                Destroy(gameObject);
                return;
            }
        }
    }
}
