using UnityEngine;
using UnityEngine.SceneManagement;

public class RHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    private float playerHealth = 100;

    public void TakeDamage(float damageTaken)
    {
        playerHealth -= damageTaken;
        healthBar.transform.localScale = new Vector3(1,playerHealth/100,1);

        
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("SkellyDeath");
        }
    }
}