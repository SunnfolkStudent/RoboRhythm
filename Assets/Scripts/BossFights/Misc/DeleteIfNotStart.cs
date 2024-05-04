using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteIfNotStart : MonoBehaviour
{
    private RSongPosition _songPosition;

    private void Start()
    {
        _songPosition = FindObjectOfType<RSongPosition>();
    }

    private void Update()
    {
        if (_songPosition.songPosition > 10)
        {
            Destroy(gameObject);
        }
    }
}
