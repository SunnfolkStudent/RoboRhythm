using UnityEngine;
using UnityEngine.SceneManagement;

public class ROtherControls : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveSystem.currentSave = 0;
            AudioManager.instance.StartMusic();
            AudioManager.instance.SetMusicRegionParameter(MusicRegion.SteamWanderer);
            SceneManager.LoadScene("MainCityScene");
        }
    }
}
