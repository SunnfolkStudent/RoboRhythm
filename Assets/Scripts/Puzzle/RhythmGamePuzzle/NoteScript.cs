using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public NoteData noteData;
    public float startTime;
    public bool isLast;
    private Rigidbody2D _rb;
    public float speed = 6f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PuzzleEvents.resetPuzzle += ResetPuzzle;
    }
    
    private void OnDisable()
    {
        PuzzleEvents.resetPuzzle -= ResetPuzzle;
    }

    private void Update()
    {
        if (Time.time >= startTime)
        {
            _rb.velocity = new Vector2(-speed, 0);
        }
    }
    
    private void ResetPuzzle()
    {
        Destroy(gameObject);
    }
    
    public void NoteHit()
    {
        if (isLast)
        {
            PuzzleEvents.puzzleCompleted?.Invoke();
        }
        Destroy(gameObject);
    }
}
