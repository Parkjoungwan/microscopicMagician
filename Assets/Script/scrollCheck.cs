using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollCheck : MonoBehaviour
{
    private bool onMiddle = false;
    
    public void setOnMiddle ()
    {
        onMiddle = true;
    }

    public bool getOnMiddle ()
    {
        return onMiddle;
    }
}
