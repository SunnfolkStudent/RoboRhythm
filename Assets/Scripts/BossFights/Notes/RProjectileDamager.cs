using UnityEngine;

public class RProjectileDamager : MonoBehaviour
{
    [SerializeField] private int dealDamage;
    
    private RHealthManager _healthManager;
    void Start()
    {
        _healthManager = FindObjectOfType<RHealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerHitBox")
        {
            Debug.Log("Hit");
            _healthManager.TakeDamage(dealDamage);
            Destroy(gameObject);
        }
    }
}
