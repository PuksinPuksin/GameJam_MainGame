using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public HyungJooPlayerManager hyungJooPlayerManager;
    private PlayerManager pm = null;
    public GameObject hit;
    private BoxCollider2D collider = null;
    private Animator animator = null;
    private Vector2 offs;
    private Vector2 siz;
    
    private void Awake()
    {
        hyungJooPlayerManager = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();    
        pm = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        offs = collider.offset;
        siz = collider.size;
    }
    private void Update()
    {
        // animator.SetBool("SetYellow", pm.button1);
        // animator.SetBool("SetBlue", !pm.button1);
        // animator.SetBool("SetGreen", pm.button1 && pm.button2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(hit);
        Debug.Log($"{hyungJooPlayerManager.Hp}");
        hyungJooPlayerManager.Hp = hyungJooPlayerManager.Hp - 1/hyungJooPlayerManager.maxHp;
        other.gameObject.SetActive(false);
        

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
 
}
