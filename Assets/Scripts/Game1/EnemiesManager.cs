using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private EnemiesScriptable[] enemiesStats;
    private ObjectPooling enemiesPool;
    private GameObject enemy;

    private void Start()
    {
        enemiesStats = Resources.FindObjectsOfTypeAll<EnemiesScriptable>();
        enemiesPool = FindObjectOfType<ObjectPooling>();
    }

    private void Update()
    {
        int ranNum = Random.Range(0, enemiesStats.Length);
        enemy = enemiesPool.RequestObject();
        enemy.GetComponent<Enemy>().SetScriptable(enemiesStats[ranNum]);
    }

    void RandomScriptable()
    {

    }
}
