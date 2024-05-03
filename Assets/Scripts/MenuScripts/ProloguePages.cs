using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProloguePages : MonoBehaviour
{
    [SerializeField] private float typingSpeed;
    [SerializeField] private string line;
    [SerializeField] private bool isFirst;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject nextPage;
    private bool canContinueToNextPage;
    private void Start()
    {
        canContinueToNextPage = false;
        StartCoroutine(DisplayLine());
        if (isFirst)
        {
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
        
        canContinueToNextPage = true;
    }

    private void Update()
    {
        if (canContinueToNextPage && Input.anyKey)
        {
            if (nextPage == null)
            {
                SceneManager.LoadScene("MainCityScene");
            }
            nextPage.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}