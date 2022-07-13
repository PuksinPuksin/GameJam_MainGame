using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHECKPREFAB : MonoBehaviour//, IPoolable
{

    public void Destroy()
    {
        Destroy(gameObject);
    }

    //public void OnPool()
    //{
    //    particle.Play();
    //    Invoke("Destroy", 0.4f);
    //}
    //private void Start()
    //{
    //    Invoke("Destroy", 0.4f);
    //}
}
