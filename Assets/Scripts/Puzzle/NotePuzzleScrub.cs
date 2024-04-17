using UnityEngine;


[System.Serializable]
public class NoteData
{
    public char note;
    public float timeToWait;
    public bool nextIsDouble;
}

[CreateAssetMenu(fileName = "NotePuzzleScrub", menuName = "Puzzle/NotePuzzleScrub")]
public class NotePuzzleScrub : ScriptableObject
{
    public NoteData[] notes;
    public float speed = 1.0f;
}
