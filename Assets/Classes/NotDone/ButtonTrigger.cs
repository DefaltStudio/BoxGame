using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour
{
    public static bool isTriggered = false;
    public Transform trigger;

    public float doorMoveSpeed = 10f;
    private Vector3 doorStartPosition;
    public Transform doorEndPosition;
    private bool doorOpen = false;

    void Awake()
    {
        doorStartPosition = trigger.transform.position;
    }

    void Update()
    {
        if (!doorOpen)
            trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition, doorMoveSpeed * Time.deltaTime);
        else if (doorOpen)
            trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.transform.position, doorMoveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            if (trigger.transform.tag == "Door")
            {
                if (doorOpen)
                    doorOpen = false;
                else
                    doorOpen = true;
            }
        }
    }
}
