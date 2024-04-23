using UnityEngine;
using UnityEngine.SceneManagement;

public class RBossHealthManager : MonoBehaviour
{
    [SerializeField] private float songLengthInSeconds;
    [SerializeField] private GameObject bossHealthBar;

    [SerializeField] private string taskId = "Piccolo";
    
    private RSongPosition _songPosition;

    private void Awake()
    {
        _songPosition = FindObjectOfType<RSongPosition>();
    }

    private void Update()
    {
        var songPercent = 1 - (_songPosition.songPosition / songLengthInSeconds);
        var localScale = bossHealthBar.transform.localScale;
        localScale = new Vector3( songPercent,localScale.y,localScale.z);
        bossHealthBar.transform.localScale = localScale;

        if (songPercent <= 0)
        {
            Debug.Log("Boss Is Defeated!!!!");
            BossDefeated();
        }
    }

    private void BossDefeated()
    {
        TaskManager.GetInstance().TaskComplete(taskId);
        SceneManager.LoadScene("PlayTestScene");
    }
}
