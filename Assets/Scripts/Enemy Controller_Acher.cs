using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class EnemyController_Acher : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public GameObject targetPoint;
    public GameObject Enemy;
    int currentpoint = 0;
    public float vel = 1f;

    public SpriteRenderer enemySprite;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = patrolPoints[currentpoint];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Enemy.transform.position,targetPoint.transform.position)>1.5f)
        {
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, targetPoint.transform.position, vel * Time.deltaTime);
        }
        else
        {
            currentpoint++;
            if (currentpoint >= patrolPoints.Length)
            targetPoint = patrolPoints[1];
        }

    }

}
