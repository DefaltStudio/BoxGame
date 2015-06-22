using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10000);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
