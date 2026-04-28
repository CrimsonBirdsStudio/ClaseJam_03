using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Profe : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public GameObject targetPoint;

    int currentPoint = 0;

    public GameObject esteban;
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
        if (Vector2.Distance(esteban.transform.position,targetPoint.transform.position)>.75f)
        {
            esteban.transform.position = Vector2.MoveTowards(esteban.transform.position, targetPoint.transform.position, vel * Time.deltaTime);
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
