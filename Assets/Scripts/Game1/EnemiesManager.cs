using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private EnemiesScriptable[] enemiesStats;
    [SerializeField] private List<Transform> spawnPointNFollowPoint;
    private ObjectPooling enemiesPool;
    private GameObject enemy;
    [SerializeField] private float timer;
    private int ranNum;
    private float time;

    private void Start()
    {
        //enemiesStats = Resources.FindObjectsOfTypeAll<EnemiesScriptable>();
        enemiesPool = FindObjectOfType<ObjectPooling>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= timer)
        {
            RandomScriptable();
            time = 0;
        }
    }

    void RandomScriptable()
    {
        ranNum = Random.Range(0, enemiesStats.Length);
        enemy = enemiesPool.RequestObject();
        RandomSpawNFollowPoint();
        enemy.GetComponent<Enemy>().SetScriptable(enemiesStats[ranNum]);
    }

    void RandomSpawNFollowPoint()
    {
        int ranNum2 = Random.Range(0, 6);
        enemy.transform.position = spawnPointNFollowPoint[ranNum2].transform.position;
        switch (ranNum2)
        {
            case 0:
                enemy.GetComponent<Enemy>().point2Follow.Add(spawnPointNFollowPoint[3]);
                break;
            case 1:
                enemy.GetComponent<Enemy>().point2Follow.Add(spawnPointNFollowPoint[5]);
                break;
            case 2:
                enemy.GetComponent<Enemy>().point2Follow.Add(spawnPointNFollowPoint[4]);
                break;
            case 3:
                enemy.GetComponent<Enemy>().point2Follow.Add(spawnPointNFollowPoint[0]);
                break;
            case 4:
                enemy.GetComponent<Enemy>().point2Follow.Add(spawnPointNFollowPoint[2]);
                break;
            case 5:
                enemy.GetComponent<Enemy>().point2Follow.Add(spawnPointNFollowPoint[1]);
                break;
            default:
                break;
        }
    }
}
