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

        switch (noteData.Key)
        {
            case "C":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.CNote, transform.position);
                break;
            case "D":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.DNote, transform.position);
                break;
            case "E":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.ENote, transform.position);
                break;
            case "F":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.FNote, transform.position);
                break;
            case "G":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.GNote, transform.position);
                break;
            case "A":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.ANote, transform.position);
                break;
            case "B":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.BNote, transform.position);
                break;
            case "CHigher":
                AudioManager.instance.PlayOneShot(FmodEvents.instance.CNoteHigher, transform.position);
                break;
        }
        Destroy(gameObject);
    }
}
