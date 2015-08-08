using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Transform Parent;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Parent.position;

		if (Input.GetButtonDown("TurnLeft") || Input.GetButtonDown("CamTurnLeft"))
		{
			//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			transform.Rotate(0, 90f, 0);
			//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
		
		if (Input.GetButtonDown("TurnRight") || Input.GetButtonDown("CamTurnRight"))
		{
			//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			transform.Rotate(0, -90f, 0);
			//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
	}
}
