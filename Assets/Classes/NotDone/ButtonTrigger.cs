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

    System.Timers.Timer doorTimer = new System.Timers.Timer();

    void Awake()
    {
        doorStartPosition = trigger.transform.position;
        doorTimer = new System.Timers.Timer(500);
        doorTimer.Elapsed += OnTimedEvent;
        doorTimer.Enabled = false;
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
                doorTimer.Enabled = true;

                //if (!doorOpen)
                //{
                //    while (trigger.transform.position != doorEndPosition.transform.position)
                //    {
                //        trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.transform.position, doorMoveSpeed);
                //        wait(1);
                //    }
                //    doorOpen = true;
                //    Debug.Log(doorOpen);
                //}
                //else if (doorOpen)
                //{
                //    while (trigger.transform.position != doorStartPosition)
                //    {
                //        trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition, doorMoveSpeed);
                //    }
                //    doorOpen = false;
                //    Debug.Log(doorOpen);
                //}
            }
        }
    }

    void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
    {
        if (!doorOpen)
        {
            if (trigger.transform.position != doorEndPosition.transform.position)
                trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.transform.position, doorMoveSpeed);
            else
            {
                doorOpen = true;
                Debug.Log(doorOpen);
                this.enabled = false;
            }
            
        }
        else
        {
            if (trigger.transform.position != doorStartPosition)
                trigger.transform.position = Vector3.MoveTowards(transform.position, doorStartPosition, doorMoveSpeed);
            else
            {
                doorOpen = false;
                Debug.Log(doorOpen);
                this.enabled = false;
            }

        }
    }
}
