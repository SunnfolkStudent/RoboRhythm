using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class NoteSpawner
{
    private NotePuzzleScrub _notePuzzleScrub;
    private GameObject _noteObj;
    
    private List<float> _startTimes = new List<float>();
    private float xSpawnPosition = 8f;
    private float _minYPosition = -4f;
    private float _maxYPosition = 1.5f;

    public NoteSpawner(NotePuzzleScrub notePuzzleScrub, GameObject noteObj)
    {
        _notePuzzleScrub = notePuzzleScrub;
        _noteObj = noteObj;
    }
    
    public void SpawnNotes()
    {
        _startTimes.Clear();
        float totalTime = Time.time + 3f;
        _startTimes.Add(totalTime);

        for (int i = 0; i < _notePuzzleScrub.notes.Length - 1; i++)
        {
            totalTime += _notePuzzleScrub.notes[i].timeToWait;
            _startTimes.Add(totalTime);
        }

        // Second loop to spawn the GameObjects
        for (int i = 0; i < _notePuzzleScrub.notes.Length; i++)
        {
            GameObject note = Object.Instantiate(_noteObj);
            
            float ySpawnPosition; // Adjust this value as needed
            
            // Calculate the total distance
            float totalDistance = _maxYPosition - _minYPosition;

            // Calculate the interval distance
            float intervalDistance = totalDistance / 5;

            // Create a list to store the positions
            List<float> spawnPositions = new List<float>();

            // Generate the positions
            for (int j = 0; j < 6; j++)
            {
                spawnPositions.Add(_minYPosition + intervalDistance * j);
                Debug.Log(_minYPosition + intervalDistance * j);
            }

            switch (_notePuzzleScrub.notes[i].KeyBind)
            {
                case 'A':
                    ySpawnPosition = spawnPositions[5];
                    break;
                case 'S':
                    ySpawnPosition = spawnPositions[4];
                    break;
                case 'D':
                    ySpawnPosition = spawnPositions[3];
                    break;
                case 'J':
                    ySpawnPosition = spawnPositions[2];
                    break;
                case 'K':
                    ySpawnPosition = spawnPositions[1];
                    break;
                default:
                    ySpawnPosition = spawnPositions[0];
                    break;
            }

            // Set the position of the note
            var position = new Vector3(xSpawnPosition, ySpawnPosition, 0);
            note.transform.position = position;

            NoteScript noteScript = note.GetComponent<NoteScript>();
            noteScript.startTime = _startTimes[i];
            noteScript.noteData = _notePuzzleScrub.notes[i];
            noteScript.speed = _notePuzzleScrub.speed;
            if (_notePuzzleScrub.notes.Length - 1 == i)
            {
                noteScript.isLast = true;
            }
        }
    }
}
