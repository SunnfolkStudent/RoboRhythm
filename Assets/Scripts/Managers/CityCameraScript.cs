using UnityEngine;

public class CityCameraScript : MonoBehaviour
{
    [SerializeField] private Camera clockRoomCamera;
    [SerializeField] private Camera mainCamera;
    private bool playerInRoom;
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRoom = true;
        }
        else
        {
            playerInRoom = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRoom = false;
        }
    }

    private void Update()
    {
        if (playerInRoom)
        {
            clockRoomCamera.enabled = true;
            mainCamera.enabled = false;
        }

        if (!playerInRoom)
        {
            clockRoomCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
