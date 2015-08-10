// Enemy Wanish? Hold kæft du staver godt Christian :P

using UnityEngine;
using System.Collections;

public class EnemyWanish : MonoBehaviour 
{
	public Transform Target;
	public Color StartColor;

	void Start () 
	{
		StartColor = Target.GetComponent<Renderer>().material.color;
	}

	void OnCollisionEnter ()
	{
		Target.GetComponent<Renderer>().material.color = Color.green;
	}

	void OnCollisionExit()
	{
		Target.GetComponent<Renderer>().material.color = StartColor;
	}
}
		    