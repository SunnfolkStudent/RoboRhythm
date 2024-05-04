using FMODUnity;
using UnityEngine;

public class FmodEvents : MonoBehaviour
{
    //[field: Header("Background Music")]
    [field: SerializeField] public EventReference BackgroundMusic { get; private set; }
    
    //[field: Header("Notes")]
    [field: SerializeField] public NoteReference[] noteReferences;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle1;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle2;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle3;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle4;
    
    public static FmodEvents instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
