using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject player1 = null;
    private GameObject player2 = null;
    private SpriteRenderer p1Renderer = null; 
    private SpriteRenderer p2Renderer = null; 

    private Color yellow = new Color(1, 1, 0);
    private Color blue = new Color(0, 1, 1);

    private void Awake()
    {
        player1 = GameObject.Find("Player1"); 
        player2 = GameObject.Find("Player2");
        p1Renderer = player1.GetComponent<SpriteRenderer>();
        p2Renderer = player2.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        p1Renderer.color = blue;
        p2Renderer.color = yellow;
    }
    private void Update()
    {
        Merge1();
        Merge2();
    }

    private void Merge1()
    {
        if(Input.GetKey(KeyCode.L))
        {
            p1Renderer.color = p2Renderer.color;
            player1.GetComponent<Collider2D>().enabled = false;
        }
        if(!Input.GetKey(KeyCode.L))
        {
            p1Renderer.color = blue;
            player1.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void Merge2()
    {
        if(Input.GetKey(KeyCode.S))
        {
            p2Renderer.color = p1Renderer.color;
            player2.GetComponent<Collider2D>().enabled = false;
        }
        if(!Input.GetKey(KeyCode.S))
        {
            p2Renderer.color = yellow;
            player2.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void BothMerge()
    {
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.L))
        {
            
        }
    }
}
