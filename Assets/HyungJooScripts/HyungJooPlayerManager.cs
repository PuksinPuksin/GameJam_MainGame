using UnityEngine;

public class HyungJooPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1 = null;
    [SerializeField] private GameObject player2 = null;
    public Sprite blue = null;
    public Sprite yellow = null;
    public Sprite green = null;
    [SerializeField] private GameObject blueMergeEffect;
    [SerializeField] private GameObject greenMergeEffect;
    [SerializeField] private GameObject orangeMergeEffect;
    [SerializeField] GameObject FXSound_1; //사운드프리펩
    [SerializeField] GameObject FXSound_2; //사운드프리펩
    private SpriteRenderer p1Renderer = null;
    [SerializeField] private bool bothSpawn = false;
    private SpriteRenderer p2Renderer = null;

    //private Color yellow = new Color(1, 1, 0);
    //private Color blue = new Color(0, 1, 1);
    //private Color green = new Color(0, 1, 0);

    public float Hp { get => hp; set { hp = value; if (hp <= 0) { popUp.GameoverPopUP(); popUp.Invoke("Asd", 0.8f); }; } }
    public float maxHp = 20;
    private float hp;

    public static bool leftSelected;
    public static bool rightSelected;
    public static bool soundBool;
    public static bool bothSelected;

    public static bool obstacleCheck1;
    public static bool obstacleCheck2;

    public bool button1 = false;
    public bool button2 = false;
    
    private GameoverPopUp popUp = null;

    private void Start()
    {
        PoolManager.CreatePool<CHECKSOUND>("Merge", transform.gameObject, 2);
        PoolManager.CreatePool<CHECKSOUND>("SuperMerge", transform.gameObject, 2);
        popUp = GameObject.Find("Canvas/GameOverPopUP").GetComponent<GameoverPopUp>();


        Time.timeScale = 1;
        p1Renderer = player1.GetComponent<SpriteRenderer>();
        p2Renderer = player2.GetComponent<SpriteRenderer>();

        p1Renderer.sprite = yellow;
        p2Renderer.sprite = blue;

        leftSelected = false;
        rightSelected = false;
        bothSelected = false;

    }
    public void LeftSelected()
    {
        if (Input.GetKey(KeyCode.S))
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
        if (Input.GetKey(KeyCode.L))
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
        if (rightSelected == true && leftSelected == true)
        {
            bothSelected = true;
            Debug.Log("B");
        }
        else
        {
            bothSelected = false;
            soundBool = false;
        }
    }
    public void ColliderCheck()
    {

        if (bothSelected == true)
        {
            if (bothSpawn)
            {
                p1Renderer.sprite = green;
                p2Renderer.sprite = green;
                player1.GetComponent<Collider2D>().enabled = false;
                player2.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                p1Renderer.sprite = green;
                p2Renderer.sprite = green;
                player1.GetComponent<Collider2D>().enabled = true;
                player2.GetComponent<Collider2D>().enabled = true;
            }

        }
        else
        {
            if (leftSelected == true)
            {
                p2Renderer.sprite = p1Renderer.sprite;
                player2.GetComponent<Collider2D>().enabled = false;
            }
            else if (leftSelected == false)
            {
                p2Renderer.sprite = yellow;

                player2.GetComponent<Collider2D>().enabled = true;
            }
            if (rightSelected == true)
            {
                p1Renderer.sprite = p2Renderer.sprite;
                player1.GetComponent<Collider2D>().enabled = false;
            }
            else if (rightSelected == false)
            {
                p1Renderer.sprite = blue;

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
        Sound();
        ColliderCheck();

    }
    private void CheckRay()
    {
        RaycastHit2D on1hit = Physics2D.Raycast(player1.transform.position, Vector2.up, 2f);
        RaycastHit2D on1hitBack = Physics2D.Raycast(player1.transform.position, Vector2.down, 2f);
        RaycastHit2D on2hit = Physics2D.Raycast(player2.transform.position, Vector2.up, 2f);
        RaycastHit2D on2hitBack = Physics2D.Raycast(player2.transform.position, Vector2.down, 2f);
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
    public void Sound()
    {

        if (bothSelected == true) //결합사운드
        {
            if (soundBool == false)
            {
                soundBool = true;
                CHECKSOUND obj = PoolManager.GetItem<CHECKSOUND>("Merge");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.L)) //결합사운드
            {
                CHECKSOUND obj = PoolManager.GetItem<CHECKSOUND>("SuperMerge");
            }
        }
    }
}


