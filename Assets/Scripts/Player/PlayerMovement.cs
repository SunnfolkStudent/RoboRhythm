using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    [Header("Movement variables")] 
    private bool _frozen;
    private float _runMoveDuration = 0.08f;
    private float _walkMoveDuration = 0.15f;
    private float _moveDuration = 0.15f;
    private float _gridSize = 0.5f;
    public bool isRunning { get; private set; }
    public bool isMoving {get; private set; }
    
    private List<Vector2> _moveQueue = new List<Vector2>();
    private int _framesToWait = 0;
    
    [HideInInspector] public Vector2 moveVector = Vector2.zero;

    private void OnEnable()
    {
        PlayerEvents.playerFrozen += FreezePlayer;
        PlayerEvents.playerUnfrozen += UnfreezePlayer;
        
        PlayerEvents.playerMovePress += PlayerMovePress;
        PlayerEvents.playerMoveRelease += PlayerMoveRelease;
        
        PlayerEvents.playerRunning += Run;
        PlayerEvents.playerNotRunning += StopRunning;
    }
    
    private void OnDisable()
    {
        PlayerEvents.playerFrozen -= FreezePlayer;
        PlayerEvents.playerUnfrozen -= UnfreezePlayer;
        
        PlayerEvents.playerMovePress -= PlayerMovePress;
        PlayerEvents.playerMoveRelease -= PlayerMoveRelease;
        
        PlayerEvents.playerRunning -= Run;
        PlayerEvents.playerNotRunning -= StopRunning;
    }
    
    private void Update()
    {
        if (_moveQueue.Count > 0 && !isMoving && !_frozen)
        {
            StartCoroutine(Move(_moveQueue.Last()));
        }

        if (_framesToWait == 0)
        {
            if (!isMoving)
            {
                moveVector = Vector2.zero;
                _framesToWait = -1;
            }
            else
            {
                _framesToWait = -1;
            }
        }
        else
        {
            _framesToWait--;
        }
    }

    private void PlayerMovePress(Vector2 direction)
    {
        foreach (var value in _moveQueue)
        {
            if (value == direction)
            {
                return;
            }
        }
        
        _moveQueue.Add(direction);
    }
    
    private void PlayerMoveRelease(Vector2 direction)
    {
        _moveQueue.Remove(direction);
    }
    
    private void Run()
    {
        _moveDuration = _runMoveDuration;
        isRunning = true;
    }
    
    private void StopRunning()
    {
        _moveDuration = _walkMoveDuration;
        isRunning = false;
    }
    
    private IEnumerator Move(Vector2 direction)
    {
        isMoving = true;
        moveVector = direction;
        
        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (direction * _gridSize);
        
        if (CheckForCollision(endPosition))
        {
            isMoving = false;
            _framesToWait = 1;
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
        
        _framesToWait = 1;
        isMoving = false; 
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
}
