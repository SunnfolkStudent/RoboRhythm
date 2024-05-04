using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RSoundEffectsManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] noteHit;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void HitSoundEffect(int noteHitNumber)
    {
        _audioSource.PlayOneShot(noteHit[noteHitNumber]);
    }
}
