using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockRoomManager : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    private bool playerInRange;
    
    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                DataPersistenceManager.instance.SaveGame();
                SceneManager.LoadScene("SkeletonBoss");
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
