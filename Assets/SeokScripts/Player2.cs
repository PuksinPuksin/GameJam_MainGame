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
    [SerializeField] private GameObject hitsound;
    private SpriteRenderer sprend = null;

    private void Awake()
    {
        pm = GameObject.Find("PlayerManager").GetComponent<HyungJooPlayerManager>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        sprend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Handheld.Vibrate();
        Instantiate(hitsound);
        StartCoroutine(Blink(3));
        Debug.Log($"{pm.Hp}");
        pm.Hp = pm.Hp - 1/pm.maxHp;
        other.gameObject.SetActive(false);
        offs = collider.offset;
        siz = collider.size;
    }
    public void SetBlue()
    {
        animator.SetBool("SetBlue", true);
        animator.SetBool("SetGreen", false);
        animator.SetBool("SetYellow", false);
        transform.localScale = new Vector3(1, 1, 1);
        //collider.size = siz;
        //collider.offset = offs;
    }
    public void SetYellow()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", false);
        animator.SetBool("SetYellow", true);
        transform.localScale = new Vector3(1, 1, 1);
        //collider.size = siz;
        //collider.offset = offs;
    }
    public void SetGreen()
    {
        animator.SetBool("SetBlue", false);
        animator.SetBool("SetGreen", true);
        animator.SetBool("SetYellow", false);
        transform.localScale = new Vector3(1, 1, 1);
        //collider.size = new Vector2(0.1f, 0.1f);
        //collider.offset = new Vector2(0, -0.01f);
    }
    private IEnumerator Blink(int roop)
    {
        for (int i = 0; i < roop; i++)
        {
            sprend.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprend.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        sprend.enabled = true;
        StopCoroutine("Blink");
    }
}
