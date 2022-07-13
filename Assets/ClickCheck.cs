using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickCheck : MonoBehaviour
{
    [SerializeField] private Button button1 = null;
    [SerializeField] private Button button2 = null;
    
    private HyungJooPlayerManager pm = null;

    private void Awake()
    {
        pm = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();
    }
    private void Update()
    {
        
    }
}
