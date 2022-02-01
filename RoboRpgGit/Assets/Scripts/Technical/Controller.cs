using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controller
{    

    public static float Horizontal()
    {
        return -Input.GetAxisRaw("Horizontal");     
    }

    public static float Vertical()
    {
        return -Input.GetAxisRaw("Vertical");       
    }

    public static bool Jump()
    {
        return Input.GetAxis("Jump") == 1;
    }

}
