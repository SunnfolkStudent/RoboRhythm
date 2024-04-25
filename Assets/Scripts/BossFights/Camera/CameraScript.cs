using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraScript : MonoBehaviour
{
    private Animator _cameraAnimator;

    private void Awake()
    {
        _cameraAnimator = GetComponent<Animator>();
    }

    public void PlaySmallZoom()
    {
        _cameraAnimator.Play("NoteHitSmall",1);
    }
}
