using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSound : MonoBehaviour
{
    public GameObject FX;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(FX);
        }       
    }
}
