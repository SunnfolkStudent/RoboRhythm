using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerMovement : MonoBehaviour
{
    [Header("Must Be 5!")]
    [SerializeField] private Vector2[] positionStates = new Vector2[5];
    private RPlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<RPlayerInput>();
    }
    
    private int currentState;

    private void Start()
    {
        currentState = 2;
        MoveToState();
    }

    private void Update()
    {
        if (playerInput.A())
        {
            if (currentState > 0)
            {
                currentState -= 1;
                MoveToState();
            }
        }
        
        if (playerInput.D())
        {
            if (currentState < 4)
            {
                currentState += 1;
                MoveToState();
            }
        }
    }

    private void MoveToState()
    {
        var o = gameObject;
        o.transform.position = new Vector3(positionStates[currentState].x,positionStates[currentState].y,o.transform.position.z);
    }
}
