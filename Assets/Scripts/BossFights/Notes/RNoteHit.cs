using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(RProjectileMovement))]
public class RNoteHit : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private int soundClipNumber;
    [Header("Best To Worst Range")]
    [SerializeField] private RRangeInformation[] rRangeInformation;

    private bool _playerInLane;
    
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
        if(!_playerInLane) {return;}
        var noteLocation = _projectileMovement.timeVariable + _projectileMovement.timeVariable1;
        for (int i = 0; i < rRangeInformation.Length; i++)
        {
            if (noteLocation > rRangeInformation[i].lowerRange && noteLocation < rRangeInformation[i].upperRange)
            {
                var rangeInfo = rRangeInformation[i];
                _scoreManager.NoteHit(rangeInfo.noteWorth,rangeInfo.scoreFeedbackNumber,rangeInfo.perfectHit);
                //_soundEffectsManager.HitSoundEffect(soundClipNumber);
                _effectsManager.OnNoteHitSmall();
                Instantiate(explosion);
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "LaneCheck")
        {
            _playerInLane = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "LaneCheck")
        {
            _playerInLane = false;
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
