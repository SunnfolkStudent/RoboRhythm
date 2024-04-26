using System;
using UnityEngine;

public class REffectsManager : MonoBehaviour
{
    private CameraScript _cameraScript;

    private void Awake()
    {
        _cameraScript = FindObjectOfType<CameraScript>();
    }

    public void OnNoteHitSmall()
    {
        Debug.Log("zoom");
        _cameraScript.PlaySmallZoom();
    }
}
