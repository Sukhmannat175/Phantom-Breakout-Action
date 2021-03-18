using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;

    [SerializeField]
    float moveSpeed = 2.0f;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[waypointIndex].transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if(transform.position == wayPoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if(waypointIndex == wayPoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
