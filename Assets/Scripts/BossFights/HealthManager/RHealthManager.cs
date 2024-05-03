using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class RHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    private float playerHealth = 100;
    private RScoreManager _scoreManager;
    private AudioSource _audioSource;

    private void Start()
    {
        _scoreManager = FindObjectOfType<RScoreManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damageTaken)
    {
        playerHealth -= damageTaken;
        healthBar.transform.localScale = new Vector3(1,playerHealth/100,1);
        _scoreManager.NoteHit(0,1,false);
        _audioSource.pitch = UnityEngine.Random.Range(0.5f, 1.5f);
        _audioSource.Play();
        
        if (playerHealth <= 0)
        {
            Debug.Log("Fix This Functionality Later");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}