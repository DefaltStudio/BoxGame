using UnityEngine;
using System.Collections;

public class Activerange : MonoBehaviour 
{
	public Transform Tower;
	
	// Update is called once per frame
	void Update () 
	{
			transform.RotateAround (Tower.position, Vector3.up, 50 * Time.deltaTime);
	}
}