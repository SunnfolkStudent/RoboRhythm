using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerInput : MonoBehaviour
{
    public bool W()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
    public bool A()
    {
        return Input.GetKeyDown(KeyCode.A);
    }
    public bool S()
    {
        return Input.GetKeyDown(KeyCode.S);
    }
    public bool D()
    {
        return Input.GetKeyDown(KeyCode.D);
    }
    public bool Space()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    
    public bool E()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
