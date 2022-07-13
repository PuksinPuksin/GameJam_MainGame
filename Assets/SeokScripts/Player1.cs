using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public HyungJooPlayerManager hyungJooPlayerManager;
    private PlayerManager pm = null;
    public GameObject hit;

    private void Awake()
    {
        hyungJooPlayerManager = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();    
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
    }
    public void SetYellow()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", false);
        animator.SetBool("SetYellow", true);
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void SetGreen()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", true);
        animator.SetBool("SetYellow", false);
        transform.localScale = new Vector3(1, 1, 1);
    }
 
}
