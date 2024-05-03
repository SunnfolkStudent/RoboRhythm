using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerChanger : MonoBehaviour
{
    private bool playerBehind = false;
    private SpriteRenderer _spriteRenderer;
    private TilemapRenderer _tilemapRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _tilemapRenderer = GetComponent<TilemapRenderer>();
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
