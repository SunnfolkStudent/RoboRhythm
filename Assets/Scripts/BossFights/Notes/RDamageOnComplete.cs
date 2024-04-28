using UnityEngine;

public class RDamageOnComplete : MonoBehaviour
{
    [SerializeField] private GameObject rowExplosion;
    [SerializeField] private int takeDamage;
    
    private RHealthManager _healthManager;
    void Start()
    {
        _healthManager = FindObjectOfType<RHealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerPlatform")
        {
            _healthManager.TakeDamage(takeDamage);
            Instantiate(rowExplosion,new Vector3(0,-4.7f,-5),Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
