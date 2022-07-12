using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private PlayerManager pm = null;

    private void Awake()
    {
        pm = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{pm.Hp}");
        pm.Hp = pm.Hp - 1/pm.maxHp;
    }
}
