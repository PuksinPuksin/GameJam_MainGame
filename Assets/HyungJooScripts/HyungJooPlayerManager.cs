using UnityEngine;

public class HyungJooPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1 = null;
    [SerializeField] private GameObject player2 = null;

    [SerializeField] private GameObject blueMergeEffect;
    [SerializeField] private GameObject greenMergeEffect;
    [SerializeField] private GameObject orangeMergeEffect;

    [SerializeField] private GameObject FXSound_1; 
    [SerializeField] private GameObject FXSound_2;
    [SerializeField] private GameObject diesound;
    
    private SpriteRenderer p1Renderer = null;
    private SpriteRenderer p2Renderer = null;

    [SerializeField] private bool bothSpawn = false;

    private Player1 p1 = null;
    private Player2 p2 = null;

    //private Color yellow = new Color(1, 1, 0);
    //private Color blue = new Color(0, 1, 1);
    //private Color green = new Color(0, 1, 0);

    public float Hp { get => hp; set { hp = value; if (hp <= 0) { popUp.GameoverPopUP(); popUp.Invoke("Asd", 0.8f); }; } }
    public float maxHp = 20;
    [SerializeField] private float hp = 1;

    public static bool leftSelected;
    public static bool rightSelected;
    public static bool soundBool;
    public static bool bothSelected;

    public static bool obstacleCheck1;
    public static bool obstacleCheck2;

    public bool button1 = false;
    public bool button2 = false;
    
    private GameoverPopUp popUp = null;

    private void Awake()
    {
        p1 = player1.GetComponent<Player1>();
        p2 = player2.GetComponent<Player2>();
    }
    private void Start()
    {
        PoolManager.CreatePool<CHECKSOUND>("Merge", transform.gameObject, 2);
        PoolManager.CreatePool<CHECKSOUND>("SuperMerge", transform.gameObject, 2);
        popUp = GameObject.Find("Canvas/GameOverPopUP").GetComponent<GameoverPopUp>();
        hp = 1;

        Time.timeScale = 1;
        p1Renderer = player1.GetComponent<SpriteRenderer>();
        p2Renderer = player2.GetComponent<SpriteRenderer>();
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
            soundBool = false;
        }
    }
    public void ColliderCheck()
    {

        if (bothSelected == true)
        {
            p1.SetGreen();
            p2.SetGreen();
            if (bothSpawn)
            {
                player1.GetComponent<Collider2D>().enabled = false;
                player2.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                player1.GetComponent<Collider2D>().enabled = true;
                player2.GetComponent<Collider2D>().enabled = true;
            }

        }
        else
        {
            if (leftSelected == true)
            {
                player2.GetComponent<Collider2D>().enabled = false;
                p2.SetBlue();
            }
            else if (leftSelected == false)
            {
                player2.GetComponent<Collider2D>().enabled = true;
                p2.SetYellow();
            }
            if (rightSelected == true)
            {
                player1.GetComponent<Collider2D>().enabled = false;
                p1.SetYellow();
            }
            else if (rightSelected == false)
            {
                player1.GetComponent<Collider2D>().enabled = true;
                p1.SetBlue();
            }
        }
    }
    private void Update()
    {
        // For Debug
        // this.button1 = Input.GetKey(KeyCode.L);
        // this.button2 = Input.GetKey(KeyCode.S);
        
        LeftSelected();
        RightSelected();
        BothSelected();
        CheckRay();
        Sound();
        ColliderCheck();
        damagesound();
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
            bothSpawn = false;
        }
    }
    public void Sound()
    {

        if (bothSelected == true) 
        {
            if (soundBool == false)
            {
                soundBool = true;
                CHECKSOUND obj = PoolManager.GetItem<CHECKSOUND>("Merge");
            }
        }
        else
        {
            if (button2 || button1)
            {
                CHECKSOUND obj = PoolManager.GetItem<CHECKSOUND>("SuperMerge");
            }
        }
    }

    public void damagesound()
    {
        if(Hp <= 0)
        {
            Instantiate(diesound);
        }
    }
}


