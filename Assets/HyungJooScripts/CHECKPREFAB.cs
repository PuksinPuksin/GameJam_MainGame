using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHECKPREFAB : MonoBehaviour
{
    private void Start()
    {
        Invoke("Destroy", 0.4f);
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
