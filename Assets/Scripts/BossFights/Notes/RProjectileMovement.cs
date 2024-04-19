using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(RProjectileSettings))]
public class RProjectileMovement : MonoBehaviour
{
    [Header("View Only")]
    public float timeVariable;
    public float timeVariable1;

    private int currentNoteState;
    
    private RProjectileSettings noteSettings;
    private RBossFightSettings bossFightSettings;
    private RSongPosition songPosition;
    private void Awake()
    {
        noteSettings = GetComponent<RProjectileSettings>();
        bossFightSettings = FindObjectOfType<RBossFightSettings>();
        songPosition = FindObjectOfType<RSongPosition>();
    }

    private void Update()
    {
        if (currentNoteState == 0)
        {
            FirstNoteState();
        }
        else if (currentNoteState == 1)
        {
            SecondNoteState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FirstNoteState()
    {
        var beatsInAdvance = bossFightSettings.beatsShownInAdvance;
        timeVariable = (beatsInAdvance - (noteSettings.beatOfThisNote - songPosition.songPosInBeats)) / beatsInAdvance;
        gameObject.transform.position = Vector2.Lerp(
            noteSettings.spawnPos,
            noteSettings.hitPosition,
            (timeVariable));
        
        if(timeVariable < 1) {return;}
        currentNoteState++;
    }

    private void SecondNoteState()
    {
        var beatsInAdvance = bossFightSettings.beatsShownInAdvance;
        timeVariable1 = (beatsInAdvance - (noteSettings.beatOfThisNote - (songPosition.songPosInBeats - beatsInAdvance))) / beatsInAdvance;
        gameObject.transform.position = Vector2.Lerp(
            noteSettings.hitPosition,
            noteSettings.removePos,
            (timeVariable1));
        
        if(timeVariable1 < 1) {return;}
        currentNoteState++;
    }
    
    
}
