using FMODUnity;
using UnityEngine;

public class FmodEvents : MonoBehaviour
{
    [field: Header("Background Music")]
    [field: SerializeField] public EventReference MainMenuMusic { get; private set; }
    
    [field: Header("Notes")]
    [field: SerializeField] public EventReference CNote { get; private set; }
    
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
