using UnityEngine;
using UnityEngine.SceneManagement;

public class RHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    private float playerHealth = 95;

    public void TakeDamage(float damageTaken)
    {
        playerHealth -= damageTaken;
        healthBar.transform.localScale = new Vector3(1,playerHealth/95,1);
        
        if (playerHealth <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}