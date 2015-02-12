using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour
{

    public static bool isTriggered = false;
    public Transform trigger;

    public float doorMoveSpeed;
    private Vector3 doorStartPosition;
    public Transform doorEndPosition;
    private bool doorOpen = false;

    void Awake()
    {
        doorStartPosition = trigger.transform.position;
    }

    void Update()
    {
        //trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.transform.position, doorMoveSpeed * Time.deltaTime);
    }

    IEnumerator wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            if (trigger.transform.tag == "Door")
            {
                if (!doorOpen)
                {
                    while (trigger.transform.position != doorEndPosition.transform.position)
                    {
                        trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.transform.position, doorMoveSpeed);
                        wait(1);
                    }
                    doorOpen = true;
                    Debug.Log(doorOpen);
                }
                else if (doorOpen)
                {
                    while (trigger.transform.position != doorStartPosition)
                    {
                        trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition, doorMoveSpeed);
                    }
                    doorOpen = false;
                    Debug.Log(doorOpen);
                }
            }
        }
    }
}
