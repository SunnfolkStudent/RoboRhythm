using UnityEngine;
using UnityEngine.SceneManagement;

public class ROtherControls : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveSystem.currentSave = 0;
            SceneManager.LoadScene("MainCityScene");
        }
    }
}
