using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class NoteScript : MonoBehaviour
{
    public float speed = 1.0f;
    public NoteData note;
    private Rigidbody2D _rb;
    private TextMeshProUGUI _textMeshPro; // Reference to the TextMeshProUGUI component

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>(); // Get the TextMeshProUGUI component from the children

        if (_textMeshPro != null) // Check if the TextMeshProUGUI component exists
        {
            _textMeshPro.text = note.note.ToString(); // Change the text
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(-speed, _rb.velocity.y);
    }
}