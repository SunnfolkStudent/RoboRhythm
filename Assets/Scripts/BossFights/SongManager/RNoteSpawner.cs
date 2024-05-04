using UnityEngine;

[RequireComponent(typeof(RBossFightSettings))]
public class RNoteSpawner : MonoBehaviour
{
    private RBossFightSettings bossFightSettings;

    private void Awake()
    {
        bossFightSettings = GetComponent<RBossFightSettings>();
    }

    public void SpawnNewNote(int noteType, float beatOfThisNote)
    {
        var noteSpawned = Instantiate(bossFightSettings.noteObjects[noteType]);

        noteSpawned.GetComponent<RProjectileSettings>().beatOfThisNote = beatOfThisNote;
        //noteSpawned.GetComponent<MusicNotes>().holdTime = notes[nextIndex].holdTime;
    }
}
