using UnityEngine;

[RequireComponent(typeof(RSongPosition))]
[RequireComponent(typeof(RNoteData))]
[RequireComponent(typeof(RNoteSpawner))]
[RequireComponent(typeof(RBossFightSettings))]

public class RNoteLogicSpawner : MonoBehaviour
{
    private int nextIndex;
    
    private RSongPosition songPosition;
    private RNoteData noteData;
    private RNoteSpawner noteSpawner;
    private RBossFightSettings bossFightSettings;
    private void Awake()
    {
        songPosition = GetComponent<RSongPosition>();
        noteData = GetComponent<RNoteData>();
        noteSpawner = GetComponent<RNoteSpawner>();
        bossFightSettings = GetComponent<RBossFightSettings>();
    }

    private void Update()
    {
        //Checks If There Are No More Notes
        if (!(nextIndex < noteData.notePropertiesArray.Length)) { return;}
        //Checks If It's The Right Beat For The Note To Spawn
        if(!(noteData.notePropertiesArray[nextIndex].beatNumber < songPosition.songPosInBeats + bossFightSettings.beatsShownInAdvance)) { return; }
        
        if (Time.timeSinceLevelLoad > 3)
        {
            noteSpawner.SpawnNewNote(noteData.notePropertiesArray[nextIndex].noteType,noteData.notePropertiesArray[nextIndex].beatNumber);
        }
        nextIndex++;
    }
}