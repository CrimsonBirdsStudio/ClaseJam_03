using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] patrolpoints;
    public GameObject targetpoint;
    int currentpoint = 0;
    public SpriteRenderer enemySprite;
    public GameObject esteban;

    float vel = 1f;
    // Start is called before the first frame update
    void Start()
    {
        targetpoint = patrolpoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(esteban.transform.position, targetpoint.transform.position) > 0.5f)
        {
            //esteban.gameObject.transform.Translate(targetpoint.transform.position * Time.deltaTime);
            esteban.transform.position = Vector2.MoveTowards(esteban.transform.position, targetpoint.transform.position, vel * Time.deltaTime);
        }
        else
        {
            currentpoint++;
            if (currentpoint >= patrolpoints.Length)
            {
                currentpoint = 0;
            }
            targetpoint = patrolpoints[currentpoint];
        }
    }
}
