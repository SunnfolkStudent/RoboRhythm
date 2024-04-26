using FMODUnity;
using UnityEngine;

public class FmodEvents : MonoBehaviour
{
    [field: SerializeField] public EventReference ExampleSound { get; private set; }
    
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
