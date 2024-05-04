using UnityEngine;

public class RProjectileDamager : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private int dealDamage;
    
    private RHealthManager _healthManager;
    void Start()
    {
        _healthManager = FindObjectOfType<RHealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("What");
        if (other.name == "PlayerHitBox")
        {
            Debug.Log("WhatTHeCrap");
            Debug.Log("Hit");
            _healthManager.TakeDamage(dealDamage);
            Instantiate(explosion,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
