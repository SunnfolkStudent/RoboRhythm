using UnityEngine;
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
        AudioManager.instance.SetMusicRegionParameter(MusicRegion.MainMenu);
        AudioManager.instance.StartMusic();
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
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        secondMenu.SetActive(true);
        firstMenu.SetActive(false);
    }
    
    public void OnNewGameClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();

        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("PrologueScene");
    }
    
    public void OnContinueGameClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        DisableMenuButtons();
          
        DataPersistenceManager.instance.SaveGame();
          
        SceneManager.LoadSceneAsync("MainCityScene");
    }

    public void OnBossModeClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        bossModeMenu.SetActive(true);
        secondMenu.SetActive(false);
    }

    public void OnQuitClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        DataPersistenceManager.instance.SaveGame();
        Application.Quit();
    }

    public void OnExitClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        secondMenu.SetActive(true);
        bossModeMenu.SetActive(false);
    }

    public void OnTrainMusicClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        _audioSource.Stop();
        AudioManager.instance.StopMusic();
        _audioSource.PlayOneShot(trainMusic);
    }
    public void OnZeppelinMusicClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        _audioSource.Stop();
        AudioManager.instance.StopMusic();
        _audioSource.PlayOneShot(zeppelinMusic);
    }
    public void OnSkeletonMusicClicked()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
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
