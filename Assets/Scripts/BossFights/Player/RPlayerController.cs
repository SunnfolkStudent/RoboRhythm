using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RPlayerController : MonoBehaviour
{
    [Header("Must Be 5!")]
    [SerializeField] private Vector2[] positionStates = new Vector2[5];
    private Controls _bossFightControls;
    private void Awake()
    {
        _bossFightControls = new Controls();
    }
    
    private int currentState;

    private void Start()
    {
        currentState = 2;
        MoveToState();
    }

    private void OnLeft()
    {
        if (currentState > 0)
        {
            currentState -= 1;
            MoveToState();
        }
    }

    private void OnRight()
    {
        if (currentState < 4)
        {
            currentState += 1;
            MoveToState();
        }
    }

    private void MoveToState()
    {
        var o = gameObject;
        o.transform.position = new Vector3(positionStates[currentState].x,positionStates[currentState].y,o.transform.position.z);
    }
}
