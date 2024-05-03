using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstMenu;
    [SerializeField] private GameObject secondMenu;
    [SerializeField] private GameObject bossModeMenu;
    
    
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    [SerializeField] private AudioClip trainMusic;
    [SerializeField] private AudioClip zeppelinMusic;
    [SerializeField] private AudioClip skeletonMusic;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        firstMenu.SetActive(true);
        secondMenu.SetActive(false);
        bossModeMenu.SetActive(false);
        
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnStartClicked()
    {
        secondMenu.SetActive(true);
        firstMenu.SetActive(false);
    }
    
    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadScene("PrologueScene");
    }
    
    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
          
        DataPersistenceManager.instance.SaveGame();
          
        SceneManager.LoadSceneAsync("MainCityScene");
    }

    public void OnBossModeClicked()
    {
        bossModeMenu.SetActive(true);
        secondMenu.SetActive(false);
    }

    public void OnQuitClicked()
    {
        DataPersistenceManager.instance.SaveGame();
        Application.Quit();
        Debug.Log("Application quit");
    }

    public void OnExitClicked()
    {
        secondMenu.SetActive(true);
        bossModeMenu.SetActive(false);
    }

    public void OnTrainMusicClicked()
    {
        _audioSource.Stop();
        AudioManager.instance.StopMusic();
        _audioSource.PlayOneShot(trainMusic);
    }
    public void OnZeppelinMusicClicked()
    {
        _audioSource.Stop();
        AudioManager.instance.StopMusic();
        _audioSource.PlayOneShot(zeppelinMusic);
    }
    public void OnSkeletonMusicClicked()
    {
        _audioSource.Stop();
        AudioManager.instance.StopMusic();
        _audioSource.PlayOneShot(skeletonMusic);
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
