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

    private bool bothClick = false;
    public bool bothSpawn = false;

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
        if(Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.S))
        {
            bothClick = true;

        }
        if (!Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.S))
        {
            bothClick = false;
            p1Renderer.color = yellow;
            p2Renderer.color= blue;
            player1.GetComponent<Collider2D>().enabled = true;
            player2.GetComponent<Collider2D>().enabled = true;
        }
        if (
            Physics2D.Raycast(player1.transform.position, Vector2.up, 1.5f).collider.isTrigger &&
            Physics2D.Raycast(player2.transform.position, Vector2.up, 1.5f).collider.isTrigger
        )
        {
            bothSpawn = true;
        }
        else
        {
            bothSpawn = false;
        }
        Summing1();
        Summing2();
        FullSumming();
    }

    private void Summing1()
    {
        if(Input.GetKey(KeyCode.L) && !bothClick)
        {
            p1Renderer.color = p2Renderer.color;
            player1.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void Summing2()
    {
        if(Input.GetKey(KeyCode.S) && !bothClick)
        {
            p2Renderer.color = p1Renderer.color;
            player2.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void FullSumming()
    {
        if (bothClick && bothSpawn)
        {
            p1Renderer.color = new Color(0, 1, 0);
            player1.GetComponent<Collider2D>().enabled = false;
            p2Renderer.color = new Color(0, 1, 0);
            player2.GetComponent<Collider2D>().enabled = false;
        }
    }
}
