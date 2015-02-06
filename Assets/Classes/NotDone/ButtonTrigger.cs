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
        Debug.Log("Trigger Enter");
        if (col.transform.tag == "Player")
        {
            Debug.Log("This is Player");
            if (trigger.transform.tag == "Door")
            {
                Debug.Log("Transform is Door");
                if (doorOpen)
                {
                    Debug.Log("Door is open");
                    trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.position, doorMoveSpeed * Time.deltaTime);
                    if (trigger.transform.position == doorEndPosition.position)
                        doorOpen = false;
                }
                else
                {
                    Debug.Log("Door is closed");
                    trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition.position, doorMoveSpeed * Time.deltaTime);
                    if (trigger.transform.position == doorStartPosition.position)
                        doorOpen = true;
                }
            }
        }
    }
}
