using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2.0f;

    private int currentPoint = 0;

    private float timeLeft;

    public GameObject hazard;
    public Vector2 spawnValue;
    public float timeBetweenAttack = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0)
        {
            timeLeft = timeBetweenAttack; 
            Vector3 spawnPosition = new Vector3(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y),1);
            Instantiate(hazard, spawnPosition, Quaternion.identity);
        }
    }

    private void Patrol()
    {
        //Calculate the vector**** current location to target location
        var vec = waypoints[currentPoint].position - transform.position;

        transform.position += vec.normalized * moveSpeed * Time.deltaTime;

        if (vec.magnitude < 0.1f)
        {
            //1%4 =1
            //2%4 =2
            //3%4 =3
            //4%4 = 0
            currentPoint = (currentPoint + 1) % 4;

        }
    }
   
}
