using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSound : MonoBehaviour
{
    public GameObject FX;
    
    public void FXsound()
    {
        Instantiate(FX);
    }
}
