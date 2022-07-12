using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

}