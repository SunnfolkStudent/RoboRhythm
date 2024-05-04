using FMOD.Studio;
using UnityEngine;

public enum Footsteps
{
    Walk = 0,
    Run = 1
}

public class PlayerSound : MonoBehaviour
{
    private EventInstance _playerSteps;
    
    void Start()
    {
        AudioManager.instance.SetMusicRegionParameter(MusicRegion.SteamWanderer);
        
        _playerSteps = AudioManager.instance.CreateEventInstance(FmodEvents.instance.steps);
    }
    
    public void PlayFootsteps()
    {
        _playerSteps.start();
    }
    
    public void StopFootsteps()
    {
        _playerSteps.stop(STOP_MODE.ALLOWFADEOUT);
    }
    
    public void SetFootstepsParameter(Footsteps footsteps)
    {
        _playerSteps.setParameterByName("Movement", (float) footsteps);
    }

    public bool StepsArePlaying()
    {
        _playerSteps.getPlaybackState(out PLAYBACK_STATE playbackState);
        return playbackState == PLAYBACK_STATE.PLAYING;
    }
    
    public Footsteps GetFootstepsParameter()
    {
        _playerSteps.getParameterByName("Movement", out float footsteps);
        return (Footsteps) footsteps;
    }
}
