using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Animator animator = null;
    public PlayerManager pm = null;

    private void Awake()
    {
        pm = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // animator.SetBool("SetYellow", pm.button1);
        // animator.SetBool("SetBlue", !pm.button1);
        // animator.SetBool("SetGreen", pm.button1 && pm.button2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log($"{pm.Hp}");
        pm.Hp = pm.Hp - 1/pm.maxHp;
        other.gameObject.SetActive(false);
    }

    public void SetBlue()
    {
        animator.SetBool("SetBlue", true);
        animator.SetBool("SetGreen", false);
        animator.SetBool("SetYellow", false);
        transform.localScale = new Vector3(12, 12, 1);
    }
    public void SetYellow()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", false);
        animator.SetBool("SetYellow", true);
        transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }
    public void SetGreen()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", true);
        animator.SetBool("SetYellow", false);
        transform.localScale = new Vector3(12, 12, 1);
    }
}
