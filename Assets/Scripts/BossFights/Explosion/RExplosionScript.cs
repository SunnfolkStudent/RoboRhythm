using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RExplosionScript : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(explosionSound);
        Destroy(gameObject,explosionSound.length);
    }
}
