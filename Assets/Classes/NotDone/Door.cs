using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    

    public Transform endPosition;
    private Transform startPosition;

    public float moveSpeed;
    private bool doorOpen;

    void Start()
    {
        doorOpen = true;
        startPosition = transform;
    }

    void Update()
    {

    }

    // transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

    static void ChangeDoorState(bool doorStateOpen)
    {
    }
}
