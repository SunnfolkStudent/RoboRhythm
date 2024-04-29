using FMODUnity;
using UnityEngine;

public class FmodEvents : MonoBehaviour
{
    [field: Header("Background Music")]
    [field: SerializeField] public EventReference BackgroundMusic { get; private set; }
    
    [field: Header("Notes")]
    [field: SerializeField] public EventReference CNote { get; private set; }
    [field: SerializeField] public EventReference DNote { get; private set; }
    [field: SerializeField] public EventReference ENote { get; private set; }
    [field: SerializeField] public EventReference FNote { get; private set; }
    [field: SerializeField] public EventReference GNote { get; private set; }
    [field: SerializeField] public EventReference ANote { get; private set; }
    [field: SerializeField] public EventReference BNote { get; private set; }
    [field: SerializeField] public EventReference CNoteHigher { get; private set; }
    
    
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
