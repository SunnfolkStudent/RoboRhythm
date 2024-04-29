using FMODUnity;
using UnityEngine;

public class FmodEvents : MonoBehaviour
{
    //[field: Header("Background Music")]
    [field: SerializeField] public EventReference BackgroundMusic { get; private set; }
    
    //[field: Header("Notes")]
    [field: SerializeField] public NoteReference[] noteReferences;
    
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
