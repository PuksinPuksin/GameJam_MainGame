using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class button1 : MonoBehaviour
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
        pm.button1 = true;
        CHECKSOUND obj = PoolManager.GetItem<CHECKSOUND>("SuperMerge");
    }
    public void SetFalse()
    {
        pm.button1 = false;
    }
}
