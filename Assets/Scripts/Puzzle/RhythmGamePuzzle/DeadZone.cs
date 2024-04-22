using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // OnTriggerEnter2D check if the object that enters the trigger has a notescript attached to it
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<NoteScript>())
        {
            // If it does, destroy the object
            PuzzleEvents.resetPuzzle?.Invoke();
        }
    }
}
