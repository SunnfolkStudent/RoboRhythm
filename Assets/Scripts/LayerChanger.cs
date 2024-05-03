using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerChanger : MonoBehaviour
{
    [SerializeField] private bool playerBehind = false;
    private SpriteRenderer _spriteRenderer;
    private TilemapRenderer _tilemapRenderer;

    private void Start()
    {
        if(_spriteRenderer != null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (_tilemapRenderer != null)
        {
            _tilemapRenderer = GetComponent<TilemapRenderer>();
        }
        playerBehind = false;
    }
    
    private void Update()
    {
        if (playerBehind)
        {
            if(_spriteRenderer != null)
            {
                _spriteRenderer.sortingLayerName = "Front of Player";
            }
            else if (_tilemapRenderer != null)
            {
                _tilemapRenderer.sortingLayerName = "Front of Player";
            }
        }
        
        if(!playerBehind)
        {
            if(_spriteRenderer != null)
            {
                _spriteRenderer.sortingLayerName = "Behind Player";
            }
            else if (_tilemapRenderer != null)
            {
                _tilemapRenderer.sortingLayerName = "Behind Player";
            }
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
