using System;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private ColourChanger _colourChanger;
    [SerializeField] private GameObject colorChangeObject;
    [SerializeField] private ParticleSystem noteParticles;
    
    private void Start()
    {
        _colourChanger = new ColourChanger(this);
    }

    private void OnEnable()
    {
        PuzzleEvents.OnKeyPressed += OnKeyPressed;
    }
    
    private void OnDisable()
    {
        PuzzleEvents.OnKeyPressed -= OnKeyPressed;
    }
    
    private void OnKeyPressed(char key)
    {
        print("Key Hit");
        bool oneIsNote = false;
        
        // Define the center of the box
        Vector2 boxCenter = transform.position;

        // Get the size of the object's collider
        Vector2 boxSize = GetComponent<Collider2D>().bounds.size;
        
        // Cast the box
        Collider2D[] hits = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0);

        // Loop through all the objects hit by the box
        foreach (var hit in hits)
        {
            print("hi");
            // Try to get the NoteScript component
            NoteScript noteScript = hit.GetComponent<NoteScript>();

            // Check if the NoteScript component exists
            if (noteScript != null)
            {
                print("hi2");
                char Note = noteScript.noteData.KeyBind;

                if (Note == key)
                {
                    print("hi3");
                    oneIsNote = true;
                    noteParticles.transform.position = hit.transform.position;
                    noteParticles.Play();
                    print("hi4");
                    hit.gameObject.GetComponent<NoteScript>().NoteHit();
                    _colourChanger.ChangeColour(colorChangeObject, Color.green);
                    print("hi5");
                }
            }
        }

        if (!oneIsNote)
        {
            print("No note hit, resetting puzzle");
            PuzzleEvents.resetPuzzle?.Invoke();
        }
    }
}
