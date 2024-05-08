using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum volumeType
    {
        Master,
        Music,
        SFX
    }
    
    [SerializeField] private volumeType _volumeType;

    private Slider _slider;

    private void Awake()
    {
        _slider = this.GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        switch (_volumeType)
        {
            case volumeType.Master:
                _slider.value = AudioManager.instance.masterVolume;
                break;
            case volumeType.Music:
                _slider.value = AudioManager.instance.musicVolume;
                break;
            case volumeType.SFX:
                _slider.value = AudioManager.instance.sfxVolume;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void OnSliderValueChanged()
    {
        switch (_volumeType)
        {
            case volumeType.Master:
                AudioManager.instance.masterVolume = _slider.value;
                break;
            case volumeType.Music:
                AudioManager.instance.musicVolume = _slider.value;
                break;
            case volumeType.SFX:
                AudioManager.instance.sfxVolume = _slider.value;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
