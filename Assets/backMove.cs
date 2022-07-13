using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backMove : MonoBehaviour
{
    [SerializeField] private GameObject back1 = null;
    [SerializeField] private GameObject back2 = null;
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        if(back1.transform.position.y <= -10)
        {
            back1.transform.position = new Vector3(0, 9, 0);
        }
        if(back2.transform.position.y <= -10)
        {
            back2.transform.position = new Vector3(0, 9, 0);
        }
        Move();
    }
    private void Move()
    {
        back1.transform.Translate(Vector3.down * Time.deltaTime * speed);
        back2.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
