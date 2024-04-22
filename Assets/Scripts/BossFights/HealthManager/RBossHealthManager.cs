using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBossHealthManager : MonoBehaviour
{
    [SerializeField] private float songLengthInSeconds;
    [SerializeField] private GameObject bossHealthBar;

    [SerializeField] private BossManager _bossManager;
    
    private RSongPosition _songPosition;

    private void Awake()
    {
        _songPosition = FindObjectOfType<RSongPosition>();
    }

    private void Update()
    {
        var songPercent = 1 - (_songPosition.songPosition / songLengthInSeconds);
        var localScale = bossHealthBar.transform.localScale;
        localScale = new Vector3( songPercent,localScale.y,localScale.z);
        bossHealthBar.transform.localScale = localScale;

        if (songPercent <= 0)
        {
            Debug.Log("Boss Is Defeated!!!!");
            BossDefeated();
        }
    }

    private void BossDefeated()
    {
        _bossManager.BossOver();
    }
}
