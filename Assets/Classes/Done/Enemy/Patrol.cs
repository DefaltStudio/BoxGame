using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour {
    public List<Transform> patrolPoints = new List<Transform>();
    public float moveSpeed;
    private int currentPoint;
    
    void Start()
    {

        transform.position = patrolPoints[currentPoint].position;
        currentPoint = 0;
    }

    void Update()
    {
        if (transform.position == patrolPoints[currentPoint].position) 
            currentPoint++;
            
        if (currentPoint >= patrolPoints.Count)
            currentPoint = 0;

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }

}
