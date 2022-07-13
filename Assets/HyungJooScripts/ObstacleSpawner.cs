using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private int obstacleRange;
    private int obstacleRangeMax = 0;
    private int obstacleRangeMin = 3;
    [SerializeField] private PlayerManager playerManager;
    public float newWaitForSeconds;

    private void Start()
    {
        newWaitForSeconds = 3f;
        ObstacleMove.speed = 5f;
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        obstacleRange = Random.Range(obstacleRangeMin, obstacleRangeMax);
        PoolManager.CreatePool<ObstacleMove>("Obstacle", transform.gameObject, 3);
        PoolManager.CreatePool<ObstacleMove>("LeftObstacle", transform.gameObject, 3);
        PoolManager.CreatePool<ObstacleMove>("RightObstacle", transform.gameObject, 3);
        StartCoroutine(ObstacleSpawn());

    }
    private void Update()
    {
        if (newWaitForSeconds > 0.3f)
        {
            newWaitForSeconds -= Time.deltaTime / 30;

        }
        if (ObstacleMove.speed < 11f)
        {
            ObstacleMove.speed += Time.deltaTime / 10;

        }
    }
    private IEnumerator ObstacleSpawn()
    {

        while (true)
        {
            obstacleRange = Random.Range(obstacleRangeMin, obstacleRangeMax);
            ObstacleCheck();
            yield return new WaitForSeconds(newWaitForSeconds);

        }
    }
    public void ObstacleCheck()
    {
        switch (obstacleRange)
        {
            case 1:
                ObstacleMove leftObj = PoolManager.GetItem<ObstacleMove>("LeftObstacle");
                leftObj.transform.SetParent(null);
                leftObj.transform.position = new Vector3(-1.25f, _stageData.LimitMax.y, 0);
                break;
            case 2:
                ObstacleMove firstObj = PoolManager.GetItem<ObstacleMove>("Obstacle");
                ObstacleMove secondObj = PoolManager.GetItem<ObstacleMove>("Obstacle");
                firstObj.transform.SetParent(null);
                secondObj.transform.SetParent(null);
                firstObj.transform.position = new Vector3(-1.25f, _stageData.LimitMax.y, 0);
                secondObj.transform.position = new Vector3(1.25f, _stageData.LimitMax.y, 0);
                break;
            case 3:
                ObstacleMove rightObj = PoolManager.GetItem<ObstacleMove>("RightObstacle");
                rightObj.transform.SetParent(null);
                rightObj.transform.position = new Vector3(1.25f, _stageData.LimitMax.y, 0);
                break;

        }
    }
}
