using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField] private StageData _stageData;

    private void FixedUpdate()
    {
        if (transform.position.y <= _stageData.LimitMin.y)
        {
            gameObject.SetActive(false);
        }
    }
}