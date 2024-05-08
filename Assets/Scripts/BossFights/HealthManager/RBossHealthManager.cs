using UnityEngine;
using UnityEngine.SceneManagement;

public class RBossHealthManager : MonoBehaviour
{
    [SerializeField] private float songLengthInSeconds;
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private TaskManager _taskManager;

    [SerializeField] private string taskId;
    
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
            BossDefeated();
        }
    }

    private void BossDefeated()
    {
        SaveSystem.currentSave = 0;
        if (!string.IsNullOrEmpty(taskId))
        {
            _taskManager.TaskComplete(taskId);
            AudioManager.instance.StartMusic();
            AudioManager.instance.SetMusicRegionParameter(MusicRegion.SteamWanderer);
            SceneManager.LoadScene("MainCityScene");
        }
        else
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
