using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RProjectileMovement))]
public class RScaleChange : MonoBehaviour
{
    [SerializeField] private float startScale;
    [SerializeField] private float endScale;

    private RProjectileMovement projectileMovement;
    
    private void Awake()
    {
        projectileMovement = GetComponent<RProjectileMovement>();
    }

    private void Update()
    {
        var newScale = (startScale +  (endScale-startScale) * ((projectileMovement.timeVariable + projectileMovement.timeVariable1)/2));
        transform.localScale = new Vector3(newScale, newScale, 1);
    }
}
