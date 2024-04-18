using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private NotePuzzleScrub notePuzzleScrub;
    [SerializeField] private GameObject notePrefab;
    
    private bool _noteCollided;
    private char _lastNote;
    private GameObject _lastNoteObject;
    [SerializeField] private GameObject flashScreen;
    
    private ColourChanger _colourChanger;
    
    // Start is called before the first frame update
    void Start()
    {
        NoteSpawner noteSpawner = new NoteSpawner(notePuzzleScrub, notePrefab, this);
        _colourChanger = new ColourChanger(this);
    }
    
    private void OnEnable()
    {
        PuzzleEvents.OnKeyPressed += ButtonTriggered;
    }
    
    private void OnDisable()
    {
        PuzzleEvents.OnKeyPressed -= ButtonTriggered;
    }
    
    
    private void ButtonTriggered(string note)
    {
        Vector3 position = transform.position;
        Vector3 scale = transform.localScale;

        // Calculate the middle bottom and middle top of the object
        Vector2 middleBottom = new Vector2(position.x, position.y - scale.y / 2);
        Vector2 middleTop = new Vector2(position.x, position.y + scale.y / 2);

        // Define a size for the box cast
        Vector2 size = new Vector2(scale.x, scale.y);

        // Send a box cast from the middle bottom to the middle top
        RaycastHit2D[] hits = Physics2D.BoxCastAll(middleBottom, size, 0, middleTop - middleBottom, (middleTop - middleBottom).magnitude);
        Debug.DrawRay(middleBottom, middleTop - middleBottom, Color.red);

        // Check if the box cast hit any notes
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                print("Found object");
                if (hit.collider.gameObject.GetComponent<NoteScript>() != null)
                {
                    print("Found note");
                    if (hit.collider.gameObject.GetComponent<NoteScript>().note.note == note)
                    {
                        print("Correct note");
                        Destroy(hit.collider.gameObject);
                        _colourChanger.ChangeColour(flashScreen, Color.green);
                    }
                }
            }
            else
            {
                Debug.Log("Missed note");
            }
        }
    }
}
