using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}
    
    private EventInstance _backgroundMusicEventInstance;

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
    }
    
    private void Start()
    {
        InitializeBGM(FmodEvents.instance.MainMenuMusic);
    }
    
    private void InitializeBGM(EventReference bgmEventReference)
    {
        _backgroundMusicEventInstance = RuntimeManager.CreateInstance(bgmEventReference);
        _backgroundMusicEventInstance.start();
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
}
