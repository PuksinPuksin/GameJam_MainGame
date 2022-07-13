using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public HyungJooPlayerManager hyungJooPlayerManager;
    private PlayerManager pm = null;

    private void Awake()
    {
        hyungJooPlayerManager = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log($"{pm.Hp}");
        hyungJooPlayerManager.Hp = hyungJooPlayerManager.Hp - 1/hyungJooPlayerManager.maxHp;
        other.gameObject.SetActive(false);
        

    }
 
}
