using UnityEngine;

public class Death : MonoBehaviour
{
    private AudioSource _deathSource;

    private void Start()
    {
        _deathSource = GetComponent<AudioSource>();
        _deathSource.Play();
    }

    private void Update()
    {
        if (SaveSystem.currentSave == 0)
        {
            Destroy(gameObject);
        }
    }
}
