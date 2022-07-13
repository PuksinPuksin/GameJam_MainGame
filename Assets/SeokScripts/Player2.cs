using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private HyungJooPlayerManager pm = null;
    public Animator animator;
    public GameObject hit;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        pm = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(hit);
        Debug.Log($"{pm.Hp}");
        pm.Hp = pm.Hp - 1/pm.maxHp;
        other.gameObject.SetActive(false);

    }
    private void Update()
    {
        ChangeAnimation();
    }
    public void ChangeAnimation()
    {
        if (HyungJooPlayerManager.bothSelected == true)
        {
            animator.SetBool("greenOn", true);
            animator.SetBool("yellowOn", false);
            animator.SetBool("blueOn", false);
        }
        else
        {
            if (HyungJooPlayerManager.leftSelected == true)
            {
                animator.SetBool("yellowOn", true);
                animator.SetBool("greenOn", false);
                animator.SetBool("blueOn", false);
            }
            if (HyungJooPlayerManager.rightSelected == true)
            {
                animator.SetBool("blueOn", true);
                animator.SetBool("yellowOn", false);
                animator.SetBool("greenOn", false);
            }
        }
    }
}
