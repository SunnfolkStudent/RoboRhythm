using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    private float playerHealth = 100;
    private RScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<RScoreManager>();
    }

    public void TakeDamage(float damageTaken)
    {
        playerHealth -= damageTaken;
        healthBar.transform.localScale = new Vector3(1,playerHealth/100,1);
        _scoreManager.NoteHit(0,1,false);
        
        if (playerHealth <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}