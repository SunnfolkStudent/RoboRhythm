using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(RProjectileMovement))]
public class RNoteHit : MonoBehaviour
{
    [Header("0-4")]
    [SerializeField] private int rowNumber;
    [Header("Other Stuff")]
    [SerializeField] private GameObject hitExplosion;
    [SerializeField] private int soundClipNumber;
    [Header("Best To Worst Range")]
    [SerializeField] private RRangeInformation[] rRangeInformation;
    
    private RProjectileMovement _projectileMovement;
    private RScoreManager _scoreManager;
    private REffectsManager _effectsManager;
    private RSoundEffectsManager _soundEffectsManager;
    
    private void Start()
    {
        _projectileMovement = GetComponent<RProjectileMovement>();
        _scoreManager = FindObjectOfType<RScoreManager>();
        _effectsManager = FindObjectOfType<REffectsManager>();
        _soundEffectsManager = FindObjectOfType<RSoundEffectsManager>();
    }
    private void AttackPressed()
    {
        if(rowNumber != RPlayerController.currentState) {return;}
        var noteLocation = _projectileMovement.timeVariable + _projectileMovement.timeVariable1;
        for (int i = 0; i < rRangeInformation.Length; i++)
        {
            if (noteLocation > rRangeInformation[i].lowerRange && noteLocation < rRangeInformation[i].upperRange)
            {
                var rangeInfo = rRangeInformation[i];
                _scoreManager.NoteHit(rangeInfo.noteWorth,rangeInfo.scoreFeedbackNumber,rangeInfo.perfectHit);
                //_soundEffectsManager.HitSoundEffect(soundClipNumber);
                _effectsManager.OnNoteHitSmall();
                Instantiate(hitExplosion,gameObject.transform.position,Quaternion.identity);
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnEnable()
    {
        RPlayerController.AttackHasOccured += AttackPressed;
    }

    private void OnDisable()
    {
        RPlayerController.AttackHasOccured -= AttackPressed;
    }
}
