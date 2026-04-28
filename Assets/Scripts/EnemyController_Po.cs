using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Po : MonoBehaviour
{
    public GameObject[] patrolPoints;       //lista de GameObjects
    public GameObject targetPoint;

    int currentPoint = 0;
    
    public GameObject enemy;
    public SpriteRenderer enemySprite;      
    public float vel = 1f;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = patrolPoints[currentPoint];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(enemy.transform.position,targetPoint.transform.position)>0.75f) 
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, targetPoint.transform.position, vel * Time.deltaTime);
        }
        else 
        {
            currentPoint++;
            if(currentPoint >= patrolPoints.Length) 
            {
                currentPoint = 0;
            }
            targetPoint = patrolPoints[currentPoint];
        }
    }
}
