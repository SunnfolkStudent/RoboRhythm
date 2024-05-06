using UnityEngine;

public class CityCameraScript : MonoBehaviour
{
    [SerializeField] private GameObject clockRoomCamera;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private bool playerInRoom;
    

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
            clockRoomCamera.SetActive(true);
            mainCamera.SetActive(false);
        }

        if (!playerInRoom)
        {
            clockRoomCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
    }
}
