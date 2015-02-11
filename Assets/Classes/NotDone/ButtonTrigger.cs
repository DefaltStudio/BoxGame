using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

    public static bool isTriggered = false;
    public GameObject trigger;

    public float doorMoveSpeed;
    private Transform doorStartPosition;
    public Transform doorEndPosition;
    private bool doorOpen = false;

	void Awake () 
	{
		doorStartPosition.position = transform.position;
	}

    void Update()
    {
        trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.position, doorMoveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            if (trigger.transform.tag == "Door")
            {
                if (!doorOpen)
                {
                    while (transform.position != doorEndPosition.position)
                    {
                        trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.position, doorMoveSpeed * Time.deltaTime);
                    }
					doorOpen = false;
                }	
                else if (doorOpen)
                {
                    while (transform.position != doorStartPosition.position)
                    {
                        trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition.position, doorMoveSpeed * Time.deltaTime);
                    }
					doorOpen = true;
                }
            }
        }
    }
}
