using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private int obstacleRange;
    private int obstacleRangeMax = 0;
    private int obstacleRangeMin = 3;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Time.timeScale = 0;
        //}
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    Time.timeScale = 1;
        //}
    }
    private void Start()
    {
        obstacleRange = Random.Range(obstacleRangeMin, obstacleRangeMax);
        PoolManager.CreatePool<ObstacleMove>("Obstacle", transform.gameObject, 3);
        PoolManager.CreatePool<ObstacleMove>("LeftObstacle", transform.gameObject, 3);
        PoolManager.CreatePool<ObstacleMove>("RightObstacle", transform.gameObject, 3);
        StartCoroutine(ObstacleSpawn());
    }
    private IEnumerator ObstacleSpawn()
    {
        while (true)
        {
            obstacleRange = Random.Range(obstacleRangeMin, obstacleRangeMax);
            ObstacleCheck();
            yield return new WaitForSeconds(1);

        }
    }
    public void ObstacleCheck()
    {
        switch (obstacleRange)
        {
            case 1:
                ObstacleMove leftObj = PoolManager.GetItem<ObstacleMove>("LeftObstacle");
                leftObj.transform.SetParent(null);
                leftObj.transform.position = new Vector3(-1, _stageData.LimitMax.y, 0);
                break;
            case 2:
                ObstacleMove firstObj = PoolManager.GetItem<ObstacleMove>("Obstacle");
                ObstacleMove secondObj = PoolManager.GetItem<ObstacleMove>("Obstacle");
                firstObj.transform.SetParent(null);
                secondObj.transform.SetParent(null);
                firstObj.transform.position = new Vector3(-1, _stageData.LimitMax.y, 0);
                secondObj.transform.position = new Vector3(1, _stageData.LimitMax.y, 0);
                break;
            case 3:
                ObstacleMove rightObj = PoolManager.GetItem<ObstacleMove>("RightObstacle");
                rightObj.transform.SetParent(null);
                rightObj.transform.position = new Vector3(1, _stageData.LimitMax.y, 0);
                break;

        }
    }
}
