using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    [Header("Movement variables")] 
    private bool _frozen;
    private float _runMoveDuration = 0.08f;
    private float _walkMoveDuration = 0.15f;
    private float _moveDuration = 0.15f;
    private float _gridSize = 0.5f;
    private bool _isMoving;
    
    [HideInInspector] public Vector2 moveVector = Vector2.zero;

    private void OnEnable()
    {
        PlayerEvents.playerFrozen += FreezePlayer;
        PlayerEvents.playerUnfrozen += UnfreezePlayer;
        
        PlayerEvents.playerDown += MoveDown;
        PlayerEvents.playerUp += MoveUp;
        PlayerEvents.playerLeft += MoveLeft;
        PlayerEvents.playerRight += MoveRight;
        
        PlayerEvents.playerRunning += Run;
        PlayerEvents.playerNotRunning += StopRunning;
    }
    
    private void OnDisable()
    {
        PlayerEvents.playerFrozen -= FreezePlayer;
        PlayerEvents.playerUnfrozen -= UnfreezePlayer;
        
        PlayerEvents.playerDown -= MoveDown;
        PlayerEvents.playerUp -= MoveUp;
        PlayerEvents.playerLeft -= MoveLeft;
        PlayerEvents.playerRight -= MoveRight;
    }

    private void MoveUp()
    {
        if (!_isMoving && !_frozen)
        {
            StartCoroutine(Move(Vector2.up));
        }
    }
    
    private void MoveDown()
    {
        if (!_isMoving && !_frozen)
        {
            StartCoroutine(Move(Vector2.down));
        }   
    }
    
    private void MoveLeft()
    {
        if (!_isMoving && !_frozen)
        {
            StartCoroutine(Move(Vector2.left));
        }
    }
    
    private void MoveRight()
    {
        if (!_isMoving && !_frozen)
        {
            StartCoroutine(Move(Vector2.right));
        }
    }
    
    private void Run()
    {
        _moveDuration = _runMoveDuration;
    }
    
    private void StopRunning()
    {
        _moveDuration = _walkMoveDuration;
    }
    
    private IEnumerator Move(Vector2 direction)
    {
        _isMoving = true;
        moveVector = direction;
        
        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (direction * _gridSize);
        
        if (CheckForCollision(endPosition))
        {
            _isMoving = false;
            StartCoroutine(TurnOffMovement());
            yield break;
        }
        
        float elapsedTime = 0;
        while (elapsedTime < _moveDuration)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, (elapsedTime / _moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = endPosition;
        PlayerEvents.playerMoved?.Invoke();
        
        StartCoroutine(TurnOffMovement());
        _isMoving = false; 
    }

    private bool CheckForCollision(Vector2 direction)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(direction, 0.1f);
        foreach (var hit in hits)
        {
            if (!hit.CompareTag("Player") && !hit.isTrigger)
            {
                return true;
            }
        }
        return false;
    }
    
    private IEnumerator TurnOffMovement()
    {
        yield return new WaitForSeconds(0.05f);
        if (_isMoving)
        {
            yield break;
        }
        moveVector = Vector2.zero;
    }
    
    private void FreezePlayer()
    {
        _frozen = true;
    }

    private void UnfreezePlayer()
    {
        _frozen = false;
    }
    
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    public void SaveTaskData(GameData data) { }
    public void LoadTaskData(GameData data) { }
    public void LoadKeyData(GameData data){}
    public void SaveKeyData(GameData data){}
}
