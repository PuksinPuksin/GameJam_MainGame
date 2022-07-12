using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1 = null;
    [SerializeField] private GameObject player2 = null;
    private SpriteRenderer p1Renderer = null;
    private SpriteRenderer p2Renderer = null;

    private Color yellow = new Color(1, 1, 0);
    private Color blue = new Color(0, 1, 1);
    private Color green = new Color(0, 1, 0);

    public float Hp { get => hp; set {hp = value; if(hp <= 0) Debug.Log("Die");}}
    public float maxHp = 20;
    private float hp;

    private bool bothSpawn = false;

    private void Awake()
    {
        // if(player1 = null) player1 = GameObject.Find("Player1");
        // if(player2 = null) player2 = GameObject.Find("Player2");   
        hp = 1;
    }
    private void Start()
    {
        p1Renderer = player1.GetComponent<SpriteRenderer>();
        p2Renderer = player2.GetComponent<SpriteRenderer>();
        p1Renderer.color = yellow;
        p2Renderer.color = blue;
    }
    private void Update()
    {
        Merge1();
        Merge2();
        BothMerge();
        CheckRay();
    }

    private void Merge1()
    {
        if(Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.S))
        {
            p1Renderer.color = p2Renderer.color;
            player1.GetComponent<Collider2D>().enabled = false;
        }
        if(!Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.S))
        {
            p1Renderer.color = yellow;
            player1.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void Merge2()
    {
        if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.L))
        {
            p2Renderer.color = p1Renderer.color;
            player1.GetComponent<Collider2D>().enabled = false;
        }
        if(!Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.L))
        {
            p2Renderer.color = blue;
            player2.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void BothMerge()
    {
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.L))
        {
            if(bothSpawn)
            {
                Debug.Log("sad");
                p1Renderer.color = green;
                p2Renderer.color = green;
                player1.GetComponent<Collider2D>().enabled = false;
                player2.GetComponent<Collider2D>().enabled = false;
            }
        }
        if(!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.L))
        {
            p1Renderer.color = yellow;
            p2Renderer.color = blue;
            player1.GetComponent<Collider2D>().enabled = true;
            player2.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void CheckRay()
    {
        RaycastHit2D on1hit = Physics2D.Raycast(player1.transform.position, Vector2.up, 2f);
        RaycastHit2D on2hit = Physics2D.Raycast(player2.transform.position, Vector2.up, 2f);
        if(on1hit && on2hit)
        {
            bothSpawn = true;
        }
        if(!on1hit)
        {
            bothSpawn = false;
        }
        if(!on2hit)
        {
            bothSpawn = false;
        }
    }
}
