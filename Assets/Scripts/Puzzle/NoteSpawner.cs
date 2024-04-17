using System.Collections;
using UnityEngine;

public class NoteSpawner
{
    private NotePuzzleScrub _notePuzzleScrub;
    private NoteData[] _notePuzzleArray;
    private GameObject _notePrefab;
    private bool _puzzleFinished;
    private float _xSpawnPosition = 5.5f;
    private float _upSpawnPosition = 2;
    private float _downSpawnPosition = -2;
    private GameObject _savedNoteObject;
    
    public NoteSpawner(NotePuzzleScrub puzzleScrub, GameObject notePrefab, MonoBehaviour monoBehaviour)
    {
        _notePuzzleScrub = puzzleScrub;
        _notePuzzleArray = puzzleScrub.notes;
        _notePrefab = notePrefab;
        monoBehaviour.StartCoroutine(Puzzle());
    }

    private IEnumerator Puzzle()
    {
        
        
        foreach (var note in _notePuzzleArray)
        {
            Vector2 spawnPosition;
            GameObject noteObject;
            
            if (_savedNoteObject != null)
            {
                int offset;
                Vector2 oldPosition = _savedNoteObject.transform.position;
                
                if (_savedNoteObject.transform.position.y > 0)
                {
                    offset = -2;
                }
                else
                {
                    offset = 2;
                }
                
                noteObject = Object.Instantiate(_notePrefab, new Vector2(oldPosition.x, oldPosition.y + offset), Quaternion.identity);
                noteObject.transform.position = new Vector3(_savedNoteObject.transform.position.x,
                    noteObject.transform.position.y, 0);
                noteObject.GetComponent<NoteScript>().note = note;
                noteObject.GetComponent<NoteScript>().speed = _notePuzzleScrub.speed;
                _savedNoteObject = null;
            }

            else
            {
                //Make spawnposistion have x value of the other spawnpositions, but y value random float between the two of them
                spawnPosition = new Vector2(_xSpawnPosition, Random.Range(_downSpawnPosition, _upSpawnPosition));
                noteObject = Object.Instantiate(_notePrefab, spawnPosition, Quaternion.identity);
                noteObject.GetComponent<NoteScript>().note = note;
                noteObject.GetComponent<NoteScript>().speed = _notePuzzleScrub.speed;
            }

            if (note.nextIsDouble)
            {
                _savedNoteObject = noteObject;
            }
            
            yield return new WaitForSeconds(note.timeToWait/_notePuzzleScrub.speed);
        }
    }
}
