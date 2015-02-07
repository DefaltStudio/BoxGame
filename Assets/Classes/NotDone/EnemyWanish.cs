// Enemy Wanish? Hold kæft du staver godt Christian :P

using UnityEngine;
using System.Collections;

public class EnemyWanish : MonoBehaviour 
{
	public Transform Target;
	public Color StartColor;

	void Start () 
	{
		StartColor = Target.renderer.material.color;
	}

	void OnCollisionEnter ()
	{
		Target.renderer.material.color = Color.green;	
	}

	void OnCollisionExit()
	{
		Target.renderer.material.color = StartColor;
	}
}
		    