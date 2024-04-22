using System;
using UnityEngine;
using UnityEngine.Scripting;

public class RNoteData : MonoBehaviour
{
    [Header("NotesFile")]
    [SerializeField,RequiredMember]
    private TextAsset file;
    
    public NoteProperties[] notePropertiesArray;
    
    private void OnValidate()
    {
        var lines = file ? file.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) : null;
        if (lines != null)
        {
            notePropertiesArray = new NoteProperties[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                notePropertiesArray[i] = ConvertToProperties(lines[i]);
            }
        }
    }

    private NoteProperties ConvertToProperties(string line)
    {
        var parts = line.Split(".");
        return new NoteProperties
        {
            noteType = int.TryParse(parts[0], out var i) ? i : 0,
            beatNumber = float.TryParse(parts[1], out var f) ? f : 0,
            holdTime = int.TryParse(parts[2], out var h) ? h : 1,
        };
    }
}
