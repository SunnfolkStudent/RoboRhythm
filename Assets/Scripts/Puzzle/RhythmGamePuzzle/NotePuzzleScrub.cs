using UnityEngine;


[System.Serializable]
public class NoteData
{
    public char KeyBind;
    public string Key;
    public float timeToWait;
}

[CreateAssetMenu(fileName = "NotePuzzleScrub", menuName = "Puzzle/NotePuzzleScrub")]
public class NotePuzzleScrub : ScriptableObject
{
    public NoteData[] notes;
    public float speed = 1.0f;
}
