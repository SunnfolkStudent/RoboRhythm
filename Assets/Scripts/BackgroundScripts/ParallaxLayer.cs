using System;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;

    private void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;

        transform.localPosition = newPos;
    }
}
