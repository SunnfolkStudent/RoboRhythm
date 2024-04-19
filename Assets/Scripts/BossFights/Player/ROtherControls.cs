using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ROtherControls : MonoBehaviour
{
    private RPlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<RPlayerInput>();
    }

    private void Update()
    {
        if (playerInput.E())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
