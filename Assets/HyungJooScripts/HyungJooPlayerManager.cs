using UnityEngine;

public class HyungJooPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1 = null;
    [SerializeField] private GameObject player2 = null;
    private SpriteRenderer p1Renderer = null;
    [SerializeField] private bool bothSpawn = false;
    private SpriteRenderer p2Renderer = null;

    private Color yellow = new Color(1, 1, 0);
    private Color blue = new Color(0, 1, 1);
    private Color green = new Color(0, 1, 0);

    public float Hp { get => hp; set { hp = value; if (hp <= 0) Debug.Log("Die"); } }
    public float maxHp = 20;
    private float hp;

    public static bool leftSelected;
    public static bool rightSelected;
    public static bool bothSelected;

    public static bool obstacleCheck1;
    public static bool obstacleCheck2;

    public bool button1 = false;
    public bool button2 = false;

    private void Start()
    {
        p1Renderer = player1.GetComponent<SpriteRenderer>();
        p2Renderer = player2.GetComponent<SpriteRenderer>();
        p1Renderer.color = yellow;
        p2Renderer.color = blue;
        leftSelected = false;
        rightSelected = false;
        bothSelected = false;
    }
    public void LeftSelected()
    {
        if (button2)
        {
            leftSelected = true;
            Debug.Log("S");
        }
        else
        {
            leftSelected = false;
        }
    }
    public void RightSelected()
    {
        if (button1)
        {
            rightSelected = true;
            Debug.Log("L");
        }
        else
        {
            rightSelected = false;
        }
    }
    public void BothSelected()
    {
        if (button2 == true && button1 == true)
        {
            bothSelected = true;
            Debug.Log("B");
        }
        else
        {
            bothSelected = false;
        }
    }
    public void ColliderCheck()
    {

        if (bothSelected == true)
        {
            if (bothSpawn)
            {
                p1Renderer.color = green;
                p2Renderer.color = green;
                player1.GetComponent<Collider2D>().enabled = false;
                player2.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                p1Renderer.color = green;
                p2Renderer.color = green;
                player1.GetComponent<Collider2D>().enabled = true;
                player2.GetComponent<Collider2D>().enabled = true;
            }

        }
        else
        {
            if (leftSelected == true)
            {
                p2Renderer.color = p1Renderer.color;
                player2.GetComponent<Collider2D>().enabled = false;
            }
            else if (leftSelected == false)
            {
                p2Renderer.color = yellow;
                player2.GetComponent<Collider2D>().enabled = true;
            }
            if (rightSelected == true)
            {
                p1Renderer.color = p2Renderer.color;
                player1.GetComponent<Collider2D>().enabled = false;
            }
            else if (rightSelected == false)
            {
                p1Renderer.color = blue;
                player1.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
    private void Update()
    {
        LeftSelected();
        RightSelected();
        BothSelected();
        CheckRay();
        //ObstacleCheck();
        ColliderCheck();
    }
    private void CheckRay()
    {
        RaycastHit2D on1hit = Physics2D.Raycast(player1.transform.position, Vector2.up, 1f);
        RaycastHit2D on1hitBack = Physics2D.Raycast(player1.transform.position, Vector2.down, 1f);
        RaycastHit2D on2hit = Physics2D.Raycast(player2.transform.position, Vector2.up, 1f);
        RaycastHit2D on2hitBack = Physics2D.Raycast(player2.transform.position, Vector2.down, 1f);
        if (on1hit && on2hit)
        {
            bothSpawn = true;
        }
        else if (on1hitBack && on2hitBack)
        {
            bothSpawn = true;
        }
        else
        {
            bothSpawn=false;
        }
    }
    //public void ObstacleCheck()
    //{
    //    if (obstacleCheck1 == true && obstacleCheck2 == true)
    //    {
    //        bothSpawn = true;
    //    }
    //    else
    //    {
    //        bothSpawn = false;
    //    }
    //}
}
