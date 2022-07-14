using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class button2 : MonoBehaviour
{
    private Button button = null;
    private HyungJooPlayerManager pm = null;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        pm = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();
    }
    
    public void SetTrue()
    {
        pm.button2 = true;
        CHECKSOUND obj = PoolManager.GetItem<CHECKSOUND>("SuperMerge");
    }
    public void SetFalse()
    {
        pm.button2 = false;
    }
}
