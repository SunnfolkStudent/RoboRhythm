using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockRoomManager : MonoBehaviour
{
    [SerializeField] private int endSceneStartId;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene(endSceneStartId);
        }
    }
}
