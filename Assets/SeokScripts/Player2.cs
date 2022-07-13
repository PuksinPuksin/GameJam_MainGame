using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private HyungJooPlayerManager pm = null;
    private Animator animator = null;
    private BoxCollider2D collider = null;
    private Vector2 offs;
    private Vector2 siz;

    private void Awake()
    {
        pm = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        offs = collider.offset;
        siz = collider.size;
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
        transform.localScale = new Vector3(1, 1, 1);
        collider.size = siz;
        collider.offset = offs;
    }
    public void SetYellow()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", false);
        animator.SetBool("SetYellow", true);
        transform.localScale = new Vector3(1, 1, 1);
        collider.size = siz;
        collider.offset = offs;
    }
    public void SetGreen()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", true);
        animator.SetBool("SetYellow", false);
        transform.localScale = new Vector3(1, 1, 1);
        collider.size = new Vector2(0.1f, 0.1f);
        collider.offset = new Vector2(0, -0.01f);
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
