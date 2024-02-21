using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public List<Transform> point2Follow;
    [SerializeField] private EnemiesScriptable enemiesScriptable;
    private ObjectPooling enemiesPool;
    private ClickEm clickEm;

    private void Start()
    {
        enemiesPool = FindObjectOfType<ObjectPooling>();
        clickEm = FindObjectOfType<ClickEm>();
        correctBug();
    }

    private void Update()
    {
        Move();
    }

    public void SetScriptable(EnemiesScriptable enemiesStats)
    {
        enemiesScriptable = enemiesStats;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemiesStats.sprite;
        gameObject.GetComponent<SpriteRenderer>().color = enemiesStats.color;
        gameObject.transform.localScale = new Vector2(enemiesStats.size, enemiesStats.size);
        BoxCollider2D bc2D = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        bc2D.isTrigger = true;
    }

    void Move()
    {
        if (point2Follow.Count > 0)
        {
            if ((point2Follow[0].position - transform.position).magnitude >= .1f)
            {
                Vector2 dir = (point2Follow[0].position - transform.position).normalized;
                transform.Translate(dir * enemiesScriptable.speed * Time.deltaTime);
            }
            else
            {
                transform.position = point2Follow[0].position;
                point2Follow.RemoveAt(0);
                enemiesPool.DespawnObject(gameObject);
            }
        }
    }

    void correctBug()
    {
        for (int i = 0; i < 2; i++)
        {
            point2Follow.RemoveAt(0);
        }
    }

    public void OnKilled()
    {
        clickEm.points += enemiesScriptable.points;
        //call the function from the pool to kill the object
        point2Follow.RemoveAt(0);
        enemiesPool.DespawnObject(gameObject);
    }        
}
