using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProloguePages : MonoBehaviour, IDataPersistence
{
    private float typingSpeed = 0.06f;
    [SerializeField] private string line;
    [SerializeField] private bool isFirst;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject nextPage;
    private bool canContinueToNextPage;
    private void Start()
    {
        Debug.Log("start of page");
        canContinueToNextPage = false;
        StartCoroutine(DisplayLine());
        StartCoroutine(TimeForNextPage());
        if (isFirst)
        {
            AudioManager.instance.StartMusic();
            AudioManager.instance.SetMusicRegionParameter(MusicRegion.Gearagedy);
        }
    }

    private IEnumerator DisplayLine()
    {
        Debug.Log("display line coroutine start");
        text.text = line;
        text.maxVisibleCharacters = 0;
            
        foreach (char letter in line.ToCharArray())
        {
            text.maxVisibleCharacters++;
            yield return new WaitForSeconds(typingSpeed);
        }
        
        canContinueToNextPage = true;
    }

    private void Update()
    {
        if (canContinueToNextPage && Input.anyKey)
        {
            Continue();
        }
    }

    private IEnumerator TimeForNextPage()
    {
        Debug.Log("next page coroutine start");
        yield return new WaitForSeconds(7.5f);
        Continue();
    }

    private void Continue()
    {
        Debug.Log("continue");
        if (nextPage == null)
        {
            SceneManager.LoadScene("MainCityScene");
        }
        else
        {
            nextPage.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
    public void LoadData(GameData data) { }

    public void SaveData(GameData data)
    {
        data.playerPosition = new Vector3(36, 95, 0);
    }
}