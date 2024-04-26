using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    private bool playerBehind = false;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        playerBehind = false;
    }
    
    private void Update()
    {
        if (playerBehind)
        {
            _spriteRenderer.sortingLayerName = "Front of Player";
        }
        
        if(!playerBehind)
        {
            _spriteRenderer.sortingLayerName = "Behind Player";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerBehind = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerBehind = false;
    }
}
