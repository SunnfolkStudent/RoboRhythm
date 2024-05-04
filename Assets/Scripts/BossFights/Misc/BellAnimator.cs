using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellAnimator : MonoBehaviour
{
    [SerializeField] private BossAnimationHolder[] bossAnimationHolder;
    private RSongPosition _songPosition;
    private Animator _animator;
    private int _currentIndex;
    void Start()
    {
        _songPosition = FindObjectOfType<RSongPosition>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentIndex > bossAnimationHolder.Length - 1) return;
        if (_songPosition.songPosInBeats > bossAnimationHolder[_currentIndex].animationBeat)
        {
            Debug.Log("Animation Chage");
            if (Time.timeSinceLevelLoad > 1)
            {
                _animator.Play(bossAnimationHolder[_currentIndex].animationName);
            }

            _currentIndex += 1;
        }
    }
}