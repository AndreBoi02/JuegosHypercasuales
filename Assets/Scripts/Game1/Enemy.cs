using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemies myEnemies;
    
    [SerializeField] private List<Transform> point2Follow;
    private EnemiesScriptable enemiesScriptable;

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
            }
        }
    }

    private void OnMouseDown()
    {
        print("WOW nice: " + enemiesScriptable.points + " points");
        //call the function from the pool to kill the object
        gameObject.SetActive(false);
    }

    enum Enemies
    {
        normal,
        fastOne,
        slowOne,
        bigOne,
        lilOne
    }
        
}
