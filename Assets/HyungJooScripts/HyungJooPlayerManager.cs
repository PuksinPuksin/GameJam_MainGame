using System.Collections;
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
    public GameObject diesound;

    private void Start()
    {
        //PoolManager.CreatePool<CHECKPREFAB>("BlueMergeEffect", transform.gameObject, 3);
        //PoolManager.CreatePool<CHECKPREFAB>("GreenMergeEffect", transform.gameObject, 10);
        //PoolManager.CreatePool<CHECKPREFAB>("OrangeMergeEffect", transform.gameObject, 3);
        PoolManager.CreatePool<CHECKSOUND>("Merge", transform.gameObject, 5);
        PoolManager.CreatePool<CHECKSOUND>("SuperMerge", transform.gameObject, 5);
        popUp = GameObject.Find("Canvas/GameOverPopUP").GetComponent<GameoverPopUp>();
        hp = 1;

        Time.timeScale = 1;
        p1Renderer = player1.GetComponent<SpriteRenderer>();
        p2Renderer = player2.GetComponent<SpriteRenderer>();

        p1Renderer.sprite = yellow;
        p2Renderer.sprite = blue;

        leftSelected = false;
        rightSelected = false;
        bothSelected = false;
        StartCoroutine(Effect());

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
                //CHECKPREFAB obj = PoolManager.GetItem<CHECKPREFAB>("GreenMergeEffect");
                //obj.transform.position = player1.transform.position;
                //CHECKPREFAB obj2 = PoolManager.GetItem<CHECKPREFAB>("GreenMergeEffect");
                //obj2.transform.position = player2.transform.position;
                player1.GetComponent<Collider2D>().enabled = false;
                player2.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                p1Renderer.sprite = green;
                p2Renderer.sprite = green;
                //CHECKPREFAB obj = PoolManager.GetItem<CHECKPREFAB>("GreenMergeEffect");
                //obj.transform.position = player1.transform.position;
                //CHECKPREFAB obj2 = PoolManager.GetItem<CHECKPREFAB>("GreenMergeEffect");
                //obj2.transform.position = player2.transform.position;
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
    private IEnumerator Effect()
    {
        while (true)
        {
            EffectSpawn();
            yield return null;
        }
    }
    public void EffectSpawn()
    {
        if(bothSelected == true)
        {
            //CHECKPREFAB obj3 = PoolManager.GetItem<CHECKPREFAB>("GreenMergeEffect");
            //obj3.transform.position = player1.transform.position;
            //CHECKPREFAB obj4 = PoolManager.GetItem<CHECKPREFAB>("GreenMergeEffect");
            //obj4.transform.position = player2.transform.position;
            GameObject obj = Instantiate(greenMergeEffect);
            obj.transform.position = player2.transform.position;
            Destroy(obj, 0.5f);
            GameObject obj2 = Instantiate(greenMergeEffect);
            obj2.transform.position = player1.transform.position;
            Destroy(obj2, 0.5f);

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                //CHECKPREFAB obj = PoolManager.GetItem<CHECKPREFAB>("BlueMergeEffect");
                //obj.transform.position = player2.transform.position;
                GameObject obj = Instantiate(blueMergeEffect);
                Destroy(obj, 0.5f);
                obj.transform.position = player2.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                //CHECKPREFAB obj2 = PoolManager.GetItem<CHECKPREFAB>("OrangeMergeEffect");
                //obj2.transform.position = player1.transform.position;
                GameObject obj2 = Instantiate(orangeMergeEffect);
                Destroy(obj2, 0.5f);
                obj2.transform.position = player1.transform.position;

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
        die();
        //EffectSpawn();

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

    public void die()
    {
        if (Hp <= 0)
        {
            Instantiate(diesound);

        }
    }
}


