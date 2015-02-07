using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

    public static bool isTriggered = false;
    public GameObject trigger;

    public float doorMoveSpeed;
    private Transform doorStartPosition;
    public Transform doorEndPosition;
    private bool doorOpen = false;

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            if (trigger.transform.tag == "Door")
            {
                if (doorOpen)
                {
                    trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.position, doorMoveSpeed * Time.deltaTime);
                    if (trigger.transform.position == doorEndPosition.position)
                        doorOpen = false;
                }
                else
                {
                    trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition.position, doorMoveSpeed * Time.deltaTime);
                    if (trigger.transform.position == doorStartPosition.position)
                        doorOpen = true;
                }
            }
        }
    }
}
