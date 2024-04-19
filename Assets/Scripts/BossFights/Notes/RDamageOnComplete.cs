using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(RProjectileMovement))]
public class RDamageOnComplete : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
