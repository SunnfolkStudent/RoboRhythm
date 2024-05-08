using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}
    
    private EventInstance _backgroundMusicEventInstance;

    private Bus _musicBus;
    
    [Range(0,1)]
    private float _musicVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        
        _musicBus = RuntimeManager.GetBus("bus:/Music");
    }

    private void OnEnable()
    {
        GameEvents.goingToMainMenu += PlayMenuMusic;
    }
    
    private void OnDisable()
    {
        GameEvents.goingToMainMenu -= PlayMenuMusic;
    }

    private void Start()
    {
        InitializeBGM(FmodEvents.instance.BackgroundMusic);
    }

    private void InitializeBGM(EventReference bgmEventReference)
    {
        _backgroundMusicEventInstance = RuntimeManager.CreateInstance(bgmEventReference);
        _backgroundMusicEventInstance.start();
    }
    
    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
        _musicBus.setVolume(_musicVolume);
    }
    
    public void StopMusic()
    {
        _backgroundMusicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    
    public void StartMusic()
    {
        _backgroundMusicEventInstance.start();
    }
    
    public void SetMusicRegionParameter(MusicRegion region)
    {
        _backgroundMusicEventInstance.setParameterByName("MusicRegion", (float) region);
    }

    public void PlayOneShot(EventReference sound, Vector3 position)
    {
        RuntimeManager.PlayOneShot(sound, position);
    }
    
    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
    
    private void PlayMenuMusic()
    {
        SetMusicRegionParameter(MusicRegion.MainMenu);
    }
}
