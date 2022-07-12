using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public static float speed;
    private void FixedUpdate()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

}