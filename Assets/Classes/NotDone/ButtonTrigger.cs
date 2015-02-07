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
		Debug.Log ("Trigger");
        if (col.transform.tag == "Player")
        {
			Debug.Log ("Collider is Player");
            if (trigger.transform.tag == "Door")
            {
				Debug.Log("Trigger tag is Door");
                if (doorOpen)
                {
					Debug.Log ("Door is open");
					while(transform != doorStartPosition)
					{
						Debug.Log ("Moving.");
						trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorEndPosition.position, doorMoveSpeed * Time.deltaTime);
					}
					doorOpen = false;
                }
                else if (!doorOpen)
                {
					Debug.Log ("Door is closed");
					while (transform != doorEndPosition)
					{
						Debug.Log ("Moving.");
						trigger.transform.position = Vector3.MoveTowards(trigger.transform.position, doorStartPosition.position, doorMoveSpeed * Time.deltaTime);
					}
					doorOpen = true;
                }
            }
        }
    }
}
