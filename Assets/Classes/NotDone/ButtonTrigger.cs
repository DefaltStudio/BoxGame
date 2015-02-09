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
		doorStartPosition = transform;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            if (trigger.transform.tag == "Door")
            {
                if (doorOpen)
                {
					while(transform != doorStartPosition)
					{
						trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.position, doorMoveSpeed * Time.deltaTime);
					}
					doorOpen = false;
                }	
                else if (!doorOpen)
                {
					while (transform != doorEndPosition)
					{
						trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition.position, doorMoveSpeed * Time.deltaTime);
					}
					doorOpen = true;
                }
            }
        }
    }
}
