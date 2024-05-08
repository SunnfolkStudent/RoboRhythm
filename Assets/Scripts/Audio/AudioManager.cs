using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}
    
    private EventInstance _backgroundMusicEventInstance;

    private Bus _masterBus;
    private Bus _musicBus;
    private Bus _sfxBus;
    
    [Range(0,1)]
    public float masterVolume = 1f;
    [Range(0,1)]
    public float musicVolume = 0.7f;
    [Range(0,1)]
    public float sfxVolume = 1f;

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
        _sfxBus = RuntimeManager.GetBus("bus:/SFX");
        _masterBus = RuntimeManager.GetBus("bus:/");
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

    private void Update()
    {
        _masterBus.setVolume(masterVolume);
        _musicBus.setVolume(musicVolume);
        _sfxBus.setVolume(sfxVolume);
    }

    private void InitializeBGM(EventReference bgmEventReference)
    {
        _backgroundMusicEventInstance = RuntimeManager.CreateInstance(bgmEventReference);
        _backgroundMusicEventInstance.start();
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
