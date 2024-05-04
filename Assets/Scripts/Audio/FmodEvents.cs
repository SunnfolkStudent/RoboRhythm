using FMODUnity;
using UnityEngine;

public class FmodEvents : MonoBehaviour
{
    [field: Header("Background Music")]
    [field: SerializeField] public EventReference BackgroundMusic { get; private set; }
    
    [field: Header("Notes")]
    [field: SerializeField] public NoteReference[] noteReferences;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle1;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle2;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle3;
    [field: SerializeField] public EventReference[] chordReferencesPuzzle4;
    
    [field: Header("SFX")]
    [field: SerializeField] public EventReference buttonClick;
    [field: SerializeField] public EventReference pushStoneStatue;
    [field: SerializeField] public EventReference pickingUpStone;
    [field: SerializeField] public EventReference stonesFalling;
    [field: SerializeField] public EventReference doorMoving;
    [field: SerializeField] public EventReference steps;
    
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
