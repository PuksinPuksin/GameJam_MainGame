using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyungJooPlayerManager : MonoBehaviour
{
    public static bool leftSelected;
    public static bool rightSelected;
    public static bool bothSelected;
    public void LeftSelected()
    {
        if(Input.GetKey(KeyCode.S))
        {
            leftSelected = true;
        }
        else
        {
            leftSelected = false;
        }
    }
    public void RightSelected()
    {
        if (Input.GetKey(KeyCode.L))
        {
            rightSelected = true;
        }
        else
        {
            rightSelected = false;
        }
    }
    public void BothSelected()
    {
        if(leftSelected == true && rightSelected == true)
        {
            bothSelected = true;
        }
    }
    private void Update()
    {
        LeftSelected();
        RightSelected();
        BothSelected();
    }
}
