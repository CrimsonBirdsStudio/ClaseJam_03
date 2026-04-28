using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public GameObject esteban;
    public SpriteRenderer enemySprite;

    public float val = 1f;
    public GameObject TargetPoint;

    int currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (patrolPoints.Length > 0)
        {
            TargetPoint = patrolPoints[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(esteban.transform.position, TargetPoint.transform.position) > .75f)
        {
            esteban.transform.position = Vector2.MoveTowards(esteban.transform.position, TargetPoint.transform.position, val * Time.deltaTime);
        }
        else
        {
            currentPoint++;
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
            TargetPoint = patrolPoints[currentPoint];
        }
    }
}
