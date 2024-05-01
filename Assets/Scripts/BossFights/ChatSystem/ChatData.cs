using System;
using UnityEngine;
using UnityEngine.Scripting;

public class ChatData : MonoBehaviour
{
    [Header("NotesFile")]
    [SerializeField,RequiredMember]
    private TextAsset file;
    
    public ChatInfoHolder[] chatInfoHolders;
    
    private void OnValidate()
    {
        var lines = file ? file.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) : null;
        if (lines != null)
        {
            chatInfoHolders = new ChatInfoHolder[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                chatInfoHolders[i] = ConvertToProperties(lines[i]);
            }
        }
    }

    private ChatInfoHolder ConvertToProperties(string line)
    {
        var parts = line.Split(";");
        return new ChatInfoHolder()
        {
            beatNumber = float.TryParse(parts[0], out var f) ? f : 0,
            stayTimeBeats = float.TryParse(parts[1], out var v) ? v : 0,
            chatText = parts[2],
        };
    }
}