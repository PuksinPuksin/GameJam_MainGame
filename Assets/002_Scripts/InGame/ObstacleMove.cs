using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private float speed = 3f;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

}
