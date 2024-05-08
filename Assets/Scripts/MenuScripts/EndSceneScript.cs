using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour
{
    [SerializeField] private bool isFirst;
    [SerializeField] private GameObject nextPage;
    [SerializeField] private float timeToWait;
    private void Start()
    {
        if (isFirst)
        {
            AudioManager.instance.StartMusic();
            AudioManager.instance.SetMusicRegionParameter(MusicRegion.Gearagedy);
        }

        StartCoroutine(GoToNextPanel());
    }

    private IEnumerator GoToNextPanel()
    {
        yield return new WaitForSeconds(timeToWait);
        if (nextPage == null)
        {
            DataPersistenceManager.instance.NewGame();
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            nextPage.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
