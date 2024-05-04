using UnityEngine;

public class RBoneDamager : MonoBehaviour
{
    [SerializeField] private int dealDamage;
    [SerializeField] private float destroyAfterSeconds;
    
    private RHealthManager _healthManager;
    void Start()
    {
        _healthManager = FindObjectOfType<RHealthManager>();
        Destroy(gameObject,destroyAfterSeconds);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerHitBox")
        {
            Debug.Log("Hit");
            _healthManager.TakeDamage(dealDamage);
        }
    }
}
