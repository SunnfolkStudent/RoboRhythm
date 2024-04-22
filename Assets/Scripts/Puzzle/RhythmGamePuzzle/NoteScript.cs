using System;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public NoteData noteData;
    public float startTime;
    public bool isLast;
    private Rigidbody2D _rb;

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
            _rb.velocity = new Vector2(-3f, 0);
        }
    }
    
    private void ResetPuzzle()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (isLast)
        {
            PuzzleEvents.puzzleCompleted?.Invoke();
        }
    }
}
