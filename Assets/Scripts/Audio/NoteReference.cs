using UnityEngine;
using FMODUnity;

public enum noteEnum
{
    C,
    CSharp,
    D,
    DSharp,
    E,
    F,
    FSharp,
    G,
    GSharp,
    A,
    ASharp,
    B,
    TopC
}

[System.Serializable]
public class NoteReference
{
    public noteEnum key;
    public EventReference noteEvent;
}
