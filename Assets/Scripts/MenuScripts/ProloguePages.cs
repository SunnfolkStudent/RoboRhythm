using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProloguePages : MonoBehaviour, IDataPersistence
{
    private float typingSpeed = 0.055f;
    [SerializeField] private string line;
    [SerializeField] private bool isFirst;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject nextPage;
    [SerializeField] private bool dontContinue;
    private bool canContinueToNextPage;
    private void Start()
    {
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
        text.text = line;
        text.maxVisibleCharacters = 0;
            
        foreach (char letter in line.ToCharArray())
        {
            text.maxVisibleCharacters++;
            yield return new WaitForSeconds(typingSpeed);
        }
        if(!dontContinue)
        {
            canContinueToNextPage = true;
        }
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
        yield return new WaitForSeconds(7.5f);
        Continue();
    }

    private void Continue()
    {
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