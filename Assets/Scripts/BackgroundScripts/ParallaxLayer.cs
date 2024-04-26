using System;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float parallaxFactor;
    [SerializeField] private float yLevel;

    private void Start()
    {
        transform.localPosition = new Vector3(0, yLevel, 0);
    }

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;

        transform.localPosition = newPos;
    }
}
